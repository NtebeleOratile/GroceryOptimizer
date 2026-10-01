using GroceryOptimizer.Models;

namespace GroceryOptimizer.Services.Interfaces;

public interface IShoppingListParser
{
    List<BasketItem> Parse(string rawInput);
}