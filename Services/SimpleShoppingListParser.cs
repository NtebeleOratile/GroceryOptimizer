using System.Text.RegularExpressions;
using GroceryOptimizer.Models;
using GroceryOptimizer.Services.Interfaces;

namespace GroceryOptimizer.Services;

public class SimpleShoppingListParser : IShoppingListParser
{
    // Matches things like: "2 x 2L milk", "2x2L milk", "3 eggs", "1 white bread"
    private static readonly Regex ItemPattern = new(
        @"(?<qty>\d+(?:\.\d+)?)?\s*(?:x\s*)?(?<size>\d+(?:\.\d+)?)?\s*(?<uom>kg|g|l|ml|each|pack|dozen)?\s*(?<name>[a-zA-Z][a-zA-Z\s]+)",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public List<BasketItem> Parse(string rawInput)
    {
        var items = new List<BasketItem>();
        if (string.IsNullOrWhiteSpace(rawInput))
            return items;

        // Split on commas, semicolons, newlines, or the word "and"
        var segments = Regex.Split(rawInput, @"[,;\n\r]+|\band\b", RegexOptions.IgnoreCase)
                            .Select(s => s.Trim())
                            .Where(s => !string.IsNullOrWhiteSpace(s));

        foreach (var segment in segments)
        {
            var item = ParseSegment(segment);
            if (item != null)
                items.Add(item);
        }

        return items;
    }

    private BasketItem? ParseSegment(string segment)
    {
        // Handle "2 x 2L milk" style first
        var multiMatch = Regex.Match(segment,
            @"^(?<qty>\d+(?:\.\d+)?)\s*x\s*(?<size>\d+(?:\.\d+)?)\s*(?<uom>kg|g|l|ml)\s+(?<name>.+)$",
            RegexOptions.IgnoreCase);

        if (multiMatch.Success)
        {
            return new BasketItem
            {
                RawText = segment,
                Quantity = decimal.Parse(multiMatch.Groups["qty"].Value),
                UnitSize = decimal.Parse(multiMatch.Groups["size"].Value),
                UnitOfMeasure = multiMatch.Groups["uom"].Value.ToLower(),
                MatchedProductName = multiMatch.Groups["name"].Value.Trim()
            };
        }

        // Fallback: try to grab a leading number as quantity
        var simpleMatch = Regex.Match(segment, @"^(?<qty>\d+(?:\.\d+)?)\s+(?<name>.+)$");
        if (simpleMatch.Success)
        {
            return new BasketItem
            {
                RawText = segment,
                Quantity = decimal.Parse(simpleMatch.Groups["qty"].Value),
                UnitSize = 1,
                UnitOfMeasure = "each",
                MatchedProductName = simpleMatch.Groups["name"].Value.Trim()
            };
        }

        // Just a product name
        return new BasketItem
        {
            RawText = segment,
            Quantity = 1,
            UnitSize = 1,
            UnitOfMeasure = "each",
            MatchedProductName = segment.Trim()
        };
    }
}