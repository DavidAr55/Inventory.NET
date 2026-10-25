namespace Inventory.Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
