using System.Collections.Generic;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Domain.Entities;

public class InventoryDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=InventoryDb;Trusted_Connection=True;ConnectRetryCount=0"
        );
    }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public int MinimumStockLevel { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}