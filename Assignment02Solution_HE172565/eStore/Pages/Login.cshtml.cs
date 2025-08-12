using BusinessObject.DTO.ApplicationUser;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eStore.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTORequest Input { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(Input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5000/api/Auth/Login", content);

            if (response.IsSuccessStatusCode)
            {
                // Ví dụ: deserialize user info nếu cần
                // var user = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync());

                // Set session/cookie nếu cần
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Sai tài khoản hoặc mật khẩu.";
                return Page();
            }
        }
    }
}
