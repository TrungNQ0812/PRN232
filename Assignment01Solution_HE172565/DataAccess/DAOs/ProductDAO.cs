using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class ProductDAO
    {
        private readonly eStoreDbContext _dbContext;

        public ProductDAO(eStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Get all products
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        // Get product by ID
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        // Add a new product
        public async Task<bool> AddProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Update an existing product
        public async Task<bool> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Delete a product
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

    }
}
