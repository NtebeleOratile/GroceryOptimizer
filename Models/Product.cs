namespace GroceryOptimizer.Models;

public class Product
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal UnitSize { get; set; }        // e.g., 2 (for 2L, 2kg)
    public string UnitOfMeasure { get; set; } = string.Empty; // L, kg, g, each
    public string RetailerId { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime LastUpdated { get; set; }
    public bool IsEstimated { get; set; }
    public bool IsPromotional { get; set; }
}