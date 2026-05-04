using FirstAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using FirstAPI.Services.Interfaces;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            return Ok();
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(CreateUserDto createUser)
        {
            return Ok();
        }
    }
}