using Microsoft.AspNetCore.Mvc;
using PRN232_PT1_TrungNQHE172565.DTOs;
using PRN232_PT1_TrungNQHE172565.Services;

namespace PRN232_PT1_TrungNQHE172565.Controllers
{
    [ApiController]
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderServices orderServices;

        public OrderController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpPost]
        [Route("CreateNewOrder")]
        public async Task<ActionResult> createNewOrder([FromBody] CreateNewOrder newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await orderServices.CreateNewOrder(newOrder);

            return null;
        }

        [HttpGet("{id}/Orders")]
        public async Task<ActionResult> GetOrdersByEmployee(int id)
        {
            var result = await orderServices.GetOrdersByEmployeeAsync(id);
            return Ok(result.Value);
        }
    }
}
