using MICHO_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;

namespace MICHO_Client.Pages.Orders
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public OrderViewModel Order { get; set; } = new();

        public List<IceCreamDTO> IceCreams { get; set; } = new();

        public async Task OnGetAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5171/api/IceCreams");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                IceCreams = JsonSerializer.Deserialize<List<IceCreamDTO>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(Order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5171/Micho/place", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return RedirectToPage("/Invoice/Details", new { orderId = JsonDocument.Parse(result).RootElement.GetProperty("OrderID").GetInt32() });
            }

            ModelState.AddModelError(string.Empty, "Order failed.");
            return Page();
        }

        public class IceCreamDTO
        {
            public int IceId { get; set; }
            public string Name { get; set; } = "";
            public decimal Price { get; set; }
        }
    }
}
