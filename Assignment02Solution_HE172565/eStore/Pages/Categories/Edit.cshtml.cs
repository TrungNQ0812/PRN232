using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace eStore.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory factory) => _httpClientFactory = factory;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
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
            var json = JsonSerializer.Serialize(Category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Categories/{Id}", content);
            if (response.IsSuccessStatusCode) return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Cập nhật thất bại");
            return Page();
        }
    }
}
