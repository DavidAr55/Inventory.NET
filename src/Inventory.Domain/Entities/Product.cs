namespace Inventory.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public int MinimumStockLevel { get; set; }
    public int CategoryId { get; set; }                 // Foreign key (the column)
    public Category Category { get; set; } = null!;     // Navigation property (the object)
}
