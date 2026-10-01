namespace GroceryOptimizer.Models;

public class BasketItem
{
    public string RawText { get; set; } = string.Empty;   // "2 x 2L milk"
    public string MatchedProductName { get; set; } = string.Empty;
    public decimal Quantity { get; set; } = 1;
    public decimal UnitSize { get; set; } = 1;
    public string UnitOfMeasure { get; set; } = "each";
    public bool IsAmbiguous { get; set; }
    public string? UserConfirmedProductId { get; set; }
}