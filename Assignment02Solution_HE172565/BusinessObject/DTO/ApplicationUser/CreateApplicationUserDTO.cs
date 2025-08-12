using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.ApplicationUser
{
	public class CreateApplicationUserDTO
	{
		public string? Username { get; set; }

		[StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất 8 ký tự", MinimumLength = 8)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
			ErrorMessage = "Mật khẩu phải có ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt")]
		public string? Password { get; set; }

		[Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
		public string? ConfirmPassword { get; set; }

		[RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|edu|gov|vn|com\.vn|info|io|co)$", ErrorMessage = "Email không hợp lệ")]
		public string? Email { get; set; }

	}
}
