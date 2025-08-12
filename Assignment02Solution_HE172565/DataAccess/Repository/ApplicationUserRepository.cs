using BusinessObject;
using BusinessObject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
	{
		public UserManager<ApplicationUser> UserManager { get; }

		public SignInManager<ApplicationUser> SignInManager { get; }
	}

	public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
	{
		public UserManager<ApplicationUser> UserManager { get; private set; }

		public SignInManager<ApplicationUser> SignInManager { get; private set; }
		public ApplicationUserRepository(eStoreDbContext context,
			UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(context)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}
	}
}
