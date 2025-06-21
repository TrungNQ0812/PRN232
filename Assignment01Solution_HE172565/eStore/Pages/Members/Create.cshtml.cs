using BusinessObject;
using BusinessObject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/MemberAPI";

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [BindProperty]
        public MemberDTO Member { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Role") != "admin")
                return RedirectToPage("/Login");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Role") != "admin")
                return RedirectToPage("/Login");

            if (!ModelState.IsValid)
                return Page();


            var json = JsonSerializer.Serialize(Member);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/create", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Members/Index");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Error: {response.StatusCode} - {errorContent}");
            return Page();
        }
    }
}
