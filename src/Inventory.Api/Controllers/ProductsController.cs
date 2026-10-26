using Inventory.Domain.Entities;
using Inventory.Infrastructure;
using Inventory.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ProductsController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll(CancellationToken ct)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync(ct);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id, CancellationToken ct)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(CreateProductRequest request, CancellationToken ct)
        {
            var product = new Product
            {
                Sku = request.Sku,
                Name = request.Name,
                Description = request.Description,
                UnitOfMeasure = request.UnitOfMeasure,
                MinimumStockLevel = request.MinimumStockLevel,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(ct);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}
