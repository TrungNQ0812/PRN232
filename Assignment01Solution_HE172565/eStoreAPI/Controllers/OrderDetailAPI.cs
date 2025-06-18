using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailAPI : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        // Constructor to inject the OrderDetailRepository
        public OrderDetailAPI(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // 1. Get all order details
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<OrderDetail>>> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailRepository.GetAllOrderDetailsAsync();
            return Ok(orderDetails);
        }

        // 2. Get order detail by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetailById(int id)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
            {
                return NotFound("Order Detail not found.");
            }
            return Ok(orderDetail);
        }

        // 3. Add a new order detail
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetail newOrderDetail)
        {
            if (newOrderDetail == null)
            {
                return BadRequest("Order detail data is required.");
            }

            bool result = await _orderDetailRepository.AddOrderDetailAsync(newOrderDetail);
            if (result)
            {
                return CreatedAtAction(nameof(GetOrderDetailById), new { id = newOrderDetail.OrderId }, newOrderDetail);
            }
            return BadRequest("Failed to create order detail.");
        }

        // 4. Update an existing order detail
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] OrderDetail updatedOrderDetail)
        {
            if (id != updatedOrderDetail.OrderId)
            {
                return BadRequest("Order detail ID mismatch.");
            }

            bool result = await _orderDetailRepository.UpdateOrderDetailAsync(updatedOrderDetail);
            if (result)
            {
                return NoContent(); // Successfully updated, no content to return
            }
            return NotFound("Order detail not found.");
        }

        // 5. Delete an order detail
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            bool result = await _orderDetailRepository.DeleteOrderDetailAsync(id);
            if (result)
            {
                return NoContent(); // Successfully deleted, no content to return
            }
            return NotFound("Order detail not found.");
        }
    }
}
