using FirstAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using FirstAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using FirstAPI.Models.Responses;

namespace FirstAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService service, ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var token = await _service.Login(login);
            _logger.LogInformation("Token: {token}", token);
            TokenResponse tokenResponse = new TokenResponse(200, token);
            return Ok(tokenResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto createUser)
        {
            var token = await _service.Register(createUser);
            _logger.LogInformation("Token: {token}", token);
            TokenResponse tokenResponse = new TokenResponse(200, token);
            return Ok(tokenResponse);
        }
    }
}