using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStoreClient.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/MemberAPI"; // Replace with your actual API URL

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public List<Member> Members { get; set; } = new();

        // GET handler to retrieve all products
        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") != "admin")
                return RedirectToPage("/Login");

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/all");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Members = JsonSerializer.Deserialize<List<Member>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return Page();
        }
    }
}
