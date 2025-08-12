using BusinessObject.DTO.ApplicationUser;
using DataAccess.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationUserController : ControllerBase
	{
		private readonly IApplicationUserService _applicationUserService;
		private readonly IAuthenticateService _authenticateService;

		public ApplicationUserController(IApplicationUserService applicationUserService, IAuthenticateService authenticateService)
		{
			_applicationUserService = applicationUserService;
			_authenticateService = authenticateService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] CreateApplicationUserDTO dto)
		{
			try
			{
				await _applicationUserService.CreateApplicationUserAsync(dto);
				return Ok(new { message = "Đăng ký thành công!" });
			}
			catch (Exception ex)
			{
				return BadRequest(new {error = ex.Message});
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDTORequest request)
		{
			try
			{
				await _authenticateService.AuthenticateCretial(request);
				return Ok(new
				{
					success = true,
					username = request.UsernameOrEmail
				});
			}
			catch(Exception ex)
			{
				return Unauthorized(new
				{
					success = false,
					message = ex.Message
				});
			}
		}

		[HttpGet("logout")]
		public async Task<IActionResult> Logout()
		{
			await _authenticateService.Logout();
			return Ok();
		}
	}
}
