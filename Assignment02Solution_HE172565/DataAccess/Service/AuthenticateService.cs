using BusinessObject.DTO.ApplicationUser;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
	public interface IAuthenticateService
	{
		public Task AuthenticateCretial(LoginDTORequest request);
		public Task Logout();
	}

	public class AuthenticateService : Service, IAuthenticateService
	{
		public AuthenticateService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task AuthenticateCretial(LoginDTORequest request)
		{
			var account = (request.UsernameOrEmail!.Contains('@'))
				? await _unitOfWork.ApplicationUsers.UserManager.FindByEmailAsync(request.UsernameOrEmail)
				: await _unitOfWork.ApplicationUsers.UserManager.FindByNameAsync(request.UsernameOrEmail)
				?? throw new Exception("Username hoặc Email không tồn tại!");

			var checkPasswork = await _unitOfWork.ApplicationUsers.SignInManager.CheckPasswordSignInAsync(account!, request.Password!, false);
			
			if(!checkPasswork.Succeeded)
				throw new Exception("Mật khẩu không chính xác!");

			await _unitOfWork.ApplicationUsers.SignInManager.PasswordSignInAsync(account!, request.Password!, request.RememberMe, lockoutOnFailure: false);
		}

		public async Task Logout()
		{
			await _unitOfWork.ApplicationUsers.SignInManager.SignOutAsync(); ;
		}
	}
}
