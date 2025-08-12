using MICHO_data.DBContext;
using MICHO_data.DTOs;
using MICHO_data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MICHO_API.Controllers
{
    [ApiController]
    [Route("Micho")]
    public class MICHO_API : Controller
    {
        private readonly MichoContext _context;
        public MICHO_API(MichoContext context) => _context = context;

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder(OrderDTO dto)
        {
            var order = new Order
            {
                Status = "Pending",
                OrderDate = DateTime.Now,
                CustomerId = dto.CustomerID,
                EmpId = dto.EmpID
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var detail = new OrderDetail
            {
                OrderId = order.OrderId,
                Quantity = dto.Items.Sum(i => i.Quantity),
                TotalAmount = dto.Items.Sum(i => i.Quantity * i.Price)
            };
            _context.OrderDetails.Add(detail);
            await _context.SaveChangesAsync();

            foreach (var item in dto.Items)
            {
                _context.OrderDetailIceCreams.Add(new OrderDetailIceCream
                {
                    OrderId = order.OrderId,
                    OrderDetailId = detail.OrderDetailId,
                    IceId = item.IceID
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { OrderID = order.OrderId });
        }
/*
        [HttpGet("invoice/{orderId}")]
        public async Task<IActionResult> GetInvoice(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                //.Include(o => o.Empl)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.OrderDetailIceCreams)
                .ThenInclude(odi => odi.IceCream)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);

            if (order == null) return NotFound();

            var invoice = new InvoiceDTO
            {
                OrderID = order.OrderID,
                CustomerName = order.Customer.Name,
                EmployeeName = order.Employee.EmpName,
                Date = order.OrderDate,
                Items = order.OrderDetails.SelectMany(od => od.OrderDetailIceCreams.Select(odi => new InvoiceItem
                {
                    Name = odi.IceCream.Name,
                    Price = odi.IceCream.Price
                })).ToList(),
                Total = order.OrderDetails.Sum(od => od.TotalAmount)
            };
            return Ok(invoice);
        }
*/
        [HttpGet("sales-report")]
        public IActionResult SalesReport(DateTime from, DateTime to)
        {
            var report = _context.Orders
                .Where(o => o.OrderDate >= from && o.OrderDate <= to)
                .Select(o => new {
                    Date = o.OrderDate.Value.Date,
                    Total = o.OrderDetails.Sum(od => od.TotalAmount)
                })
                .GroupBy(o => o.Date)
                .Select(g => new {
                    Date = g.Key,
                    Total = g.Sum(x => x.Total)
                });

            return Ok(report);
        }

        [HttpGet("stats")]
        public IActionResult GetStatistics()
        {
            var peakHours = _context.Orders
                .GroupBy(o => o.OrderDate.Value.Hour)
                .Select(g => new { Hour = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(3)
                .ToList();

            var bestSellers = _context.OrderDetailIceCreams
                .GroupBy(x => x.IceId)
                .Select(g => new {
                    IceID = g.Key,
                    Count = g.Count(),
                    Name = _context.IceCreams.First(ic => ic.IceId == g.Key).Name
                })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            return Ok(new { PeakHours = peakHours, BestSellers = bestSellers });
        }
    }
}
