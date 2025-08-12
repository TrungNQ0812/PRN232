using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStore.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _factory;

        public IndexModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public List<Category> Categories { get; set; } = new();

        public async Task OnGetAsync()
        {
            var client = _factory.CreateClient("eStoreAPI");
            var response = await client.GetAsync("api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Categories = JsonSerializer.Deserialize<List<Category>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
    }
}
