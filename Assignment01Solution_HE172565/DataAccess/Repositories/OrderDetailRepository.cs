using BusinessObject;
using DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _orderDetailDAO;

        public OrderDetailRepository(OrderDetailDAO orderDetailDAO)
        {
            _orderDetailDAO = orderDetailDAO;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _orderDetailDAO.GetAllOrderDetailsAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId)
        {
            return await _orderDetailDAO.GetOrderDetailByIdAsync(orderDetailId);
        }

        public async Task<bool> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _orderDetailDAO.AddOrderDetailAsync(orderDetail);
        }

        public async Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _orderDetailDAO.UpdateOrderDetailAsync(orderDetail);
        }

        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            return await _orderDetailDAO.DeleteOrderDetailAsync(orderDetailId);
        }
    }
}
