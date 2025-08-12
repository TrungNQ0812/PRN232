using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace eStore.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory factory) => _httpClientFactory = factory;

        [BindProperty]
        public CategoryDTO Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var client = _httpClientFactory.CreateClient("eStoreAPI");
            var json = JsonSerializer.Serialize(Category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/Categories", content);
            if (response.IsSuccessStatusCode) return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Thêm thất bại");
            return Page();
        }
    }
}
