using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class OrderDAO
    {
        private readonly eStoreDbContext _dbContext;

        public OrderDAO(eStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all orders
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.Member)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        // Get order by ID
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.Member)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        // Add a new order
        public async Task<bool> AddOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Update an existing order
        public async Task<bool> UpdateOrderAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Delete an order
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

    }
}
