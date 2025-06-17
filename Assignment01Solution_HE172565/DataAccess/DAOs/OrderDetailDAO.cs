using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class OrderDetailDAO
    {
        private readonly eStoreDbContext _dbContext;

        public OrderDetailDAO(eStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all order details
        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _dbContext.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.Order)
                .ToListAsync();
        }

        // Get order detail by ID
        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId)
        {
            return await _dbContext.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.Order)
                .FirstOrDefaultAsync(od => od.Id == orderDetailId);
        }

        // Add a new order detail
        public async Task<bool> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Update an existing order detail
        public async Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Delete an order detail
        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            var orderDetail = await _dbContext.OrderDetails.FindAsync(orderDetailId);
            if (orderDetail != null)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

    }
}
