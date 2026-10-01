using GroceryOptimizer.Models;

namespace GroceryOptimizer.Services.Interfaces;

public interface IBasketOptimizer
{
    BasketResult Optimize(List<BasketItem> items, BasketStrategy strategy);
}