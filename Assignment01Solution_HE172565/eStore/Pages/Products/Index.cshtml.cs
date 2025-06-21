using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using System.Text.Json;
using System.Text;

namespace eStoreClient.Pages.Products
{
    public class IndexModel : PageModel
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/ProductAPI"; // Replace with your actual API URL

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public List<Product> Products { get; set; } = new();

        // GET handler to retrieve all products
        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/all");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Products = JsonSerializer.Deserialize<List<Product>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return Page();
        }
    }
}
