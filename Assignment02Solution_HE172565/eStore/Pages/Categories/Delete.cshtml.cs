using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStore.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory factory) => _httpClientFactory = factory;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public CategoryDTO Category { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("eStoreAPI");
            var response = await client.GetAsync($"/api/Categories/{Id}");

            if (!response.IsSuccessStatusCode) return NotFound();

            var content = await response.Content.ReadAsStringAsync();
            Category = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("eStoreAPI");
            var response = await client.DeleteAsync($"/api/Categories/{Id}");

            return RedirectToPage("Index");
        }
    }
}
