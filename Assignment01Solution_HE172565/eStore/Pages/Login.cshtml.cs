using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eStoreClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public LoginModel(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            var adminSection = _configuration.GetSection("AdminAccount");
            string adminEmail = adminSection["Email"];
            string adminPassword = adminSection["Password"];

            if (Email == adminEmail && Password == adminPassword)
            {
                HttpContext.Session.SetString("Role", "admin");
                return RedirectToPage("/Index");
            }

            // Gọi API để kiểm tra tài khoản thường
            try
            {
                string apiUrl = $"http://localhost:5000/api/MemberAPI/{Email}";
                var response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var member = JsonSerializer.Deserialize<Member>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (member != null && member.Password == Password)
                    {
                        HttpContext.Session.SetString("Role", "member");
                        HttpContext.Session.SetString("MemberEmail", member.Email);
                        return RedirectToPage("/Index");
                    }
                }

                ErrorMessage = "Invalid email or password.";
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred while connecting to the API.";
                return Page();
            }
        }
    }
}
