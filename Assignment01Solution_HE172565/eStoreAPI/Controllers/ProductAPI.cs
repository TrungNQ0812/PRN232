using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPI : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        // Constructor to inject the product repository
        public ProductAPI(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // 1. Get all products
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        // 2. Get product by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        // 3. Add a new product
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product data is required.");
            }

            bool result = await _productRepository.AddProductAsync(newProduct);
            if (result)
            {
                return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);
            }
            return BadRequest("Failed to create product.");
        }

        // 4. Update an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            bool result = await _productRepository.UpdateProductAsync(updatedProduct);
            if (result)
            {
                return NoContent(); // Successfully updated, no content to return
            }
            return NotFound("Product not found.");
        }

        // 5. Delete a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = await _productRepository.DeleteProductAsync(id);
            if (result)
            {
                return NoContent(); // Successfully deleted, no content to return
            }
            return NotFound("Product not found.");
        }
    }
}
