using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStoreClient.Pages.OrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/OrderDetailAPI"; // Replace with your actual API URL

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public List<OrderDetail> OrderDetails { get; set; } = new();

        // GET handler to retrieve all products
        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/all");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                OrderDetails = JsonSerializer.Deserialize<List<OrderDetail>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return Page();
        }
    }
}
