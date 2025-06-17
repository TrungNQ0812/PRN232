using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
