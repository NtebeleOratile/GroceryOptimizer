using GroceryOptimizer.Models;

namespace GroceryOptimizer.Services.Interfaces;

public interface IProductMatcher
{
    List<BasketItem> MatchItems(List<BasketItem> items);
}