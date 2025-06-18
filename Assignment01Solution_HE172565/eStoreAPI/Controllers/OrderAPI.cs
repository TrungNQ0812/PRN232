using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPI : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        // Constructor to inject the OrderRepository
        public OrderAPI(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // 1. Get all orders
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        // 2. Get order by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }
            return Ok(order);
        }

        // 3. Add a new order
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddOrder([FromBody] Order newOrder)
        {
            if (newOrder == null)
            {
                return BadRequest("Order data is required.");
            }

            bool result = await _orderRepository.AddOrderAsync(newOrder);
            if (result)
            {
                return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderId }, newOrder);
            }
            return BadRequest("Failed to create order.");
        }

        // 4. Update an existing order
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            if (id != updatedOrder.OrderId)
            {
                return BadRequest("Order ID mismatch.");
            }

            bool result = await _orderRepository.UpdateOrderAsync(updatedOrder);
            if (result)
            {
                return NoContent(); // Successfully updated, no content to return
            }
            return NotFound("Order not found.");
        }

        // 5. Delete an order
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            bool result = await _orderRepository.DeleteOrderAsync(id);
            if (result)
            {
                return NoContent(); // Successfully deleted, no content to return
            }
            return NotFound("Order not found.");
        }
    }
}
