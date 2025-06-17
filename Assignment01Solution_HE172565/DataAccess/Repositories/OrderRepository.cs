using BusinessObject;
using DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;

        public OrderRepository(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderDAO.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderDAO.GetOrderByIdAsync(orderId);
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            return await _orderDAO.AddOrderAsync(order);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _orderDAO.UpdateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await _orderDAO.DeleteOrderAsync(orderId);
        }
    }
}
