using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStoreClient.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/ProductAPI";

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public Product ProductToDelete { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("Role") != "admin")
                return RedirectToPage("/Login");

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/all");
            if (response.IsSuccessStatusCode)
            {
                var listJson = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<Product>>(listJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ProductToDelete = list?.FirstOrDefault(m => m.ProductId == id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/delete/{id}");
            return RedirectToPage("/Products/Index");
        }
    }
}
