using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN232_PT1_TrungNQHE172565.DTOs;
using PRN232_PT1_TrungNQHE172565.Models;

namespace PRN232_PT1_TrungNQHE172565.Services
{
    public class OrderService : IOrderServices
    {
        private readonly Prn232dbContext dbContext;

        public OrderService(Prn232dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ActionResult> CreateNewOrder(CreateNewOrder order)
        {
            Order newOrder = new Order
            {
                Status = order.Status,
                OrderDate = order.OrderDate,
                EmpId = order.EmpId
            };

            dbContext.Orders.Add(newOrder);
            await dbContext.SaveChangesAsync();

            return new OkObjectResult(new { message = "Order created successfully!"}); 
        }


        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByEmployeeAsync(int empId)
        {
            var orders = await dbContext.Orders
                .Where(o => o.EmpId == empId)
                .ToListAsync();

            return orders;
        }


    }
}
