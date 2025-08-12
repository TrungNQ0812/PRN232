using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace eStore.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public EditModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _clientFactory.CreateClient("eStoreAPI");
            var response = await client.GetAsync($"/api/Products/{id}");

            if (!response.IsSuccessStatusCode) return RedirectToPage("Index");

            var json = await response.Content.ReadAsStringAsync();
            Product = JsonSerializer.Deserialize<Product>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("eStoreAPI");

            var json = JsonSerializer.Serialize(Product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/products/{Product.ProductId}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Cập nhật thất bại");
            return Page();
        }
    }
}
