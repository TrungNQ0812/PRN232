using BusinessObject;
using DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository(ProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productDAO.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _productDAO.GetProductByIdAsync(productId);
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            return await _productDAO.AddProductAsync(product);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            return await _productDAO.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            return await _productDAO.DeleteProductAsync(productId);
        }
    }
}
