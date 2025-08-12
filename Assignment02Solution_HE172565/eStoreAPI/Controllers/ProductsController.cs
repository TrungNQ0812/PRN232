using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products); // List<ProductDTO>
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.CreateProductAsync(dto);
            return Ok(new { message = "Product created successfully." });
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existing = await _service.GetProductByIdAsync(id);
            if (existing == null) return NotFound();
            var product = new Product
            {
                ProductName = dto.ProductName,
                Weight = dto.Weight,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                CategoryId = dto.CategoryId
            };
            await _service.UpdateProductAsync(product);
            return Ok(new { message = "Product updated successfully." });
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetProductByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteProductAsync(id);
            return Ok(new { message = "Product deleted successfully." });
        }
    }
}
