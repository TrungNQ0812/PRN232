using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStoreClient.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/MemberAPI";

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [BindProperty]
        public Member MemberToDelete { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("Role") != "admin")
                return RedirectToPage("/Login");

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/all");
            if (response.IsSuccessStatusCode)
            {
                var listJson = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<Member>>(listJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                MemberToDelete = list?.FirstOrDefault(m => m.MemberId == id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/delete/{id}");
            return RedirectToPage("/Members/Index");
        }
    }
}
