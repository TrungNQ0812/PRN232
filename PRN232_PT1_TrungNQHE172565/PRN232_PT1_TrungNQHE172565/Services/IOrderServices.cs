using Microsoft.AspNetCore.Mvc;
using PRN232_PT1_TrungNQHE172565.DTOs;
using PRN232_PT1_TrungNQHE172565.Models;

namespace PRN232_PT1_TrungNQHE172565.Services
{
    public interface IOrderServices
    {
        Task<ActionResult> CreateNewOrder(CreateNewOrder order);
        Task<ActionResult<IEnumerable<Order>>> GetOrdersByEmployeeAsync(int empId);
    }
}
