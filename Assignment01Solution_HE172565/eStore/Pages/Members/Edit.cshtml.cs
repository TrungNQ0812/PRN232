using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;
using BusinessObject;
using BusinessObject.DTOs;

namespace eStoreClient.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5000/api/MemberAPI";

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [BindProperty]
        public MemberDTO MemberToEdit { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("Role") != "admin")
                return RedirectToPage("/Login");

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/all");
            if (response.IsSuccessStatusCode)
            {
                var listJson = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<Member>>(listJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var member = list?.FirstOrDefault(m => m.MemberId == id);

                if (member != null)
                {
                    MemberToEdit = new MemberDTO
                    {
                        MemberId = member.MemberId,
                        Email = member.Email,
                        CompanyName = member.CompanyName,
                        City = member.City,
                        Country = member.Country,
                        Password = member.Password
                    };
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("Role") != "admin")
            {
                return RedirectToPage("/Login");
            }
            if (!ModelState.IsValid) return Page();

            var json = JsonSerializer.Serialize(MemberToEdit);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiBaseUrl}/update/{MemberToEdit.MemberId}", content);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("/Members/Index");

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", $"Update failed: {error}");

            return Page();
        }
    }
}
