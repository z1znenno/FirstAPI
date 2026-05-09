using Microsoft.AspNetCore.Mvc;
using FirstAPI.Services.Interfaces;
using FirstAPI.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var user = await _userService.GetByIdAsync(userId);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            await _userService.DeleteAsync(userId);
            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Change(string name, int age, string login)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            await _userService.ChangeUserData(userId, name, age, login);
            return Ok();
        }
    }
}