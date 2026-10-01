namespace GroceryOptimizer.Models;

public class BasketResult
{
    public List<BasketItem> Items { get; set; } = new();
    public List<RetailerBasketTotal> RetailerTotals { get; set; } = new();

    public RetailerBasketTotal? CheapestOneStore { get; set; }
    public SplitShopResult? CheapestSplit { get; set; }

    public decimal PotentialSaving =>
        (CheapestOneStore?.Total ?? 0) - (CheapestSplit?.Total ?? 0);

    public string Explanation { get; set; } = string.Empty;
}

public class SplitShopResult
{
    public decimal Total { get; set; }
    public List<RetailerBasketTotal> RetailerBreakdown { get; set; } = new();
}