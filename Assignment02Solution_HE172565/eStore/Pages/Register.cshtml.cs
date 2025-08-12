using BusinessObject.DTO.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace eStore.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public CreateApplicationUserDTO Input { get; set; } = new CreateApplicationUserDTO();

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient("eStoreAPI");
            var content = new StringContent(JsonSerializer.Serialize(Input), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/ApplicationUser/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                var responseText = await response.Content.ReadAsStringAsync();
                ErrorMessage = "Đăng ký thất bại: " + responseText;
                return Page();
            }
        }
    }
}
