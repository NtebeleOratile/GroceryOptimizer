namespace GroceryOptimizer.Models;

public class RetailerBasketTotal
{
    public Retailer Retailer { get; set; } = new();
    public decimal Total { get; set; }
    public List<BasketLineResult> Lines { get; set; } = new();
    public int ItemsFound { get; set; }
    public int ItemsMissing { get; set; }
}

public class BasketLineResult
{
    public BasketItem Item { get; set; } = new();
    public Product? Product { get; set; }
    public decimal LineTotal { get; set; }
    public decimal UnitPrice { get; set; }
    public bool IsAvailable { get; set; }
}