using BusinessObject.DTO.ApplicationUser;
using BusinessObject.Models;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
	public interface IApplicationUserService
	{
		public Task CreateApplicationUserAsync(CreateApplicationUserDTO dto);
	}

	public class ApplicationUserService : Service, IApplicationUserService
	{
		public ApplicationUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task CreateApplicationUserAsync(CreateApplicationUserDTO dto)
		{
			var entityUser = new ApplicationUser
			{
				UserName = dto.Username,
				Email = dto.Email,
			};

			var create = await _unitOfWork.ApplicationUsers.UserManager.CreateAsync(entityUser, dto.Password!);
			if(!create.Succeeded)
			{
				var error = create.Errors.First().Code;

				if (error == "DuplicateUserName")
					throw new Exception("Tên đăng nhập đã tồn tại!");

				if (error == "DuplicationEmail")
					throw new Exception("Email đã tồn tại!");
			}

			await _unitOfWork.SaveAsync();
		}
	}
}
