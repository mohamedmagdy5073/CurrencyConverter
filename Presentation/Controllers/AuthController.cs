using Application.Identity.Dtos;
using Application.Identity.Interfaces;
using Application.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthDto>> RegisterAsync(RegisterDto model)
        {
            var result = await _identityService.RegisterAsync(model);

            SetTokenInCookie(result.Token, result.ExpiresOn);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthDto>> LoginAsync(LoginDto model)
        {
            var result = await _identityService.GetTokenAsync(model);

            SetTokenInCookie(result.Token, result.ExpiresOn);

            return Ok(result);
        }

        //[Authorize]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<PagedResponse<UserDto>>> GetUsers(int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _identityService.GetUsersAsync(pageNumber, pageSize));
        }

        [Authorize]
        [HttpPost("AddRoleToUser")]
        public async Task<ActionResult<AddRoleToUserDto>> AddRoleToUserAsync(AddRoleToUserDto model)
        {
            await _identityService.AddRoleAsync(model);

            return Ok(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("RemoveRoleFromUser")]
        public async Task<ActionResult<string>> RemoveRoleFromUserAsync(AddRoleToUserDto model)
        {
            return Ok(await _identityService.RemoveRoleAsync(model));
        }

        private void SetTokenInCookie(string token, DateTime? expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires?.ToLocalTime()
            };

            Response.Cookies.Append("Token", token, cookieOptions);
        }

        [Authorize]
        [HttpDelete("Logout")]
        public async Task<ActionResult<string>> LogoutAsync()
        {
            Response.Cookies.Delete("Token");

            return Ok("Logged out succefully");
        }
    }
}
