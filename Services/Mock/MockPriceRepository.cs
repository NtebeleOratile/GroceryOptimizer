using GroceryOptimizer.Models;
using GroceryOptimizer.Services.Interfaces;

namespace GroceryOptimizer.Services.Mock;

public class MockPriceRepository : IPriceRepository
{
    private readonly List<Retailer> _retailers = new()
    {
        new Retailer { Id = "checkers", Name = "Checkers" },
        new Retailer { Id = "shoprite", Name = "Shoprite" },
        new Retailer { Id = "picknpay", Name = "Pick n Pay" },
        new Retailer { Id = "woolworths", Name = "Woolworths" }
    };

    private readonly List<Product> _products = new()
    {
        // Milk
        new Product { Id = "m1", Name = "Full Cream Milk 2L", Brand = "House Brand", Category = "Dairy", UnitSize = 2, UnitOfMeasure = "L", RetailerId = "checkers",   Price = 34.99m, LastUpdated = DateTime.Now.AddHours(-3) },
        new Product { Id = "m2", Name = "Full Cream Milk 2L", Brand = "House Brand", Category = "Dairy", UnitSize = 2, UnitOfMeasure = "L", RetailerId = "shoprite",   Price = 33.99m, LastUpdated = DateTime.Now.AddHours(-2) },
        new Product { Id = "m3", Name = "Full Cream Milk 2L", Brand = "House Brand", Category = "Dairy", UnitSize = 2, UnitOfMeasure = "L", RetailerId = "picknpay",   Price = 35.49m, LastUpdated = DateTime.Now.AddHours(-5) },
        new Product { Id = "m4", Name = "Full Cream Milk 2L", Brand = "House Brand", Category = "Dairy", UnitSize = 2, UnitOfMeasure = "L", RetailerId = "woolworths", Price = 39.99m, LastUpdated = DateTime.Now.AddHours(-1) },

        // White Bread
        new Product { Id = "b1", Name = "White Bread Loaf", Brand = "Albany", Category = "Bakery", UnitSize = 700, UnitOfMeasure = "g", RetailerId = "checkers",   Price = 18.99m, LastUpdated = DateTime.Now.AddHours(-4) },
        new Product { Id = "b2", Name = "White Bread Loaf", Brand = "Albany", Category = "Bakery", UnitSize = 700, UnitOfMeasure = "g", RetailerId = "shoprite",   Price = 17.99m, LastUpdated = DateTime.Now.AddHours(-3) },
        new Product { Id = "b3", Name = "White Bread Loaf", Brand = "Albany", Category = "Bakery", UnitSize = 700, UnitOfMeasure = "g", RetailerId = "picknpay",   Price = 18.49m, LastUpdated = DateTime.Now.AddHours(-6) },

        // Eggs
        new Product { Id = "e1", Name = "Large Eggs 30s", Brand = "House Brand", Category = "Dairy", UnitSize = 30, UnitOfMeasure = "each", RetailerId = "checkers",   Price = 74.99m, LastUpdated = DateTime.Now.AddHours(-2) },
        new Product { Id = "e2", Name = "Large Eggs 30s", Brand = "House Brand", Category = "Dairy", UnitSize = 30, UnitOfMeasure = "each", RetailerId = "shoprite",   Price = 72.99m, LastUpdated = DateTime.Now.AddHours(-1) },
        new Product { Id = "e3", Name = "Large Eggs 30s", Brand = "House Brand", Category = "Dairy", UnitSize = 30, UnitOfMeasure = "each", RetailerId = "picknpay",   Price = 76.99m, LastUpdated = DateTime.Now.AddHours(-8) },

        // Chicken
        new Product { Id = "c1", Name = "Chicken Breast 2kg", Brand = "House Brand", Category = "Meat", UnitSize = 2, UnitOfMeasure = "kg", RetailerId = "checkers",   Price = 189.99m, LastUpdated = DateTime.Now.AddHours(-3) },
        new Product { Id = "c2", Name = "Chicken Breast 2kg", Brand = "House Brand", Category = "Meat", UnitSize = 2, UnitOfMeasure = "kg", RetailerId = "shoprite",   Price = 171.99m, LastUpdated = DateTime.Now.AddHours(-2) },
        new Product { Id = "c3", Name = "Chicken Breast 2kg", Brand = "House Brand", Category = "Meat", UnitSize = 2, UnitOfMeasure = "kg", RetailerId = "picknpay",   Price = 184.99m, LastUpdated = DateTime.Now.AddHours(-7) },

        // Rice
        new Product { Id = "r1", Name = "White Rice 5kg", Brand = "Tastic", Category = "Grains", UnitSize = 5, UnitOfMeasure = "kg", RetailerId = "checkers",   Price = 89.99m, LastUpdated = DateTime.Now.AddHours(-5) },
        new Product { Id = "r2", Name = "White Rice 5kg", Brand = "Tastic", Category = "Grains", UnitSize = 5, UnitOfMeasure = "kg", RetailerId = "shoprite",   Price = 84.99m, LastUpdated = DateTime.Now.AddHours(-4) },
        new Product { Id = "r3", Name = "White Rice 5kg", Brand = "Tastic", Category = "Grains", UnitSize = 5, UnitOfMeasure = "kg", RetailerId = "picknpay",   Price = 92.99m, LastUpdated = DateTime.Now.AddHours(-9) },
    };

    public List<Retailer> GetRetailers() => _retailers;
    public List<Product> GetProducts() => _products;

    public List<Product> SearchProducts(string term)
    {
        if (string.IsNullOrWhiteSpace(term)) return new List<Product>();
        var t = term.ToLowerInvariant();
        return _products
            .Where(p => p.Name.ToLowerInvariant().Contains(t))
            .ToList();
    }
}