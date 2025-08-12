using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;

        public ProductService(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync() => _productRepo.GetAllAsync();

        public Task<Product?> GetProductByIdAsync(int id) => _productRepo.GetByIdAsync(id);

        public Task UpdateProductAsync(Product product) => _productRepo.UpdateAsync(product);

        public Task DeleteProductAsync(int id) => _productRepo.DeleteAsync(id);

        public async Task CreateProductAsync(ProductDTO dto)
        {
            await _productRepo.AddAsync(dto);
        }
    }
}
