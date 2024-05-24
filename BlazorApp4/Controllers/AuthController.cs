// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using BlazorApp4.Shared;
using BlazorApp4.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var authenticatedUser = _userService.Authenticate(user.Username, user.Password);
            if (authenticatedUser == null)
                return Unauthorized();

            return Ok(authenticatedUser);
        }
    }
}
