using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> AddOrderDetailAsync(OrderDetail orderDetail);
        Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
    }
}
