using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public Task<bool> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
