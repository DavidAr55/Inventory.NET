namespace Inventory.Api.Dtos
{
    public record CreateProductRequest(
        string Sku,
        string Name,
        string? Description,
        string UnitOfMeasure,
        int MinimumStockLevel,
        int CategoryId);
}
