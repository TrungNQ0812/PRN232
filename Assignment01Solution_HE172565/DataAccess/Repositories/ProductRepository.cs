using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<bool> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
