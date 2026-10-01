using GroceryOptimizer.Models;

namespace GroceryOptimizer.Services.Interfaces;

public interface IPriceRepository
{
    List<Retailer> GetRetailers();
    List<Product> GetProducts();
    List<Product> SearchProducts(string term);
}