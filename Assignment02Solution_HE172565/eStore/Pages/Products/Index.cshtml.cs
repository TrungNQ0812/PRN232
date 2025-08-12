using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStore.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("eStoreAPI");
            var response = await client.GetAsync("/api/Products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Products = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                Products = new List<Product>();
            }
        }
    }
}
