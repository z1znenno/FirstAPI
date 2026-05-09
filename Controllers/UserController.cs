using Microsoft.AspNetCore.Mvc;
using FirstAPI.Services.Interfaces;
using FirstAPI.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FirstAPI.DTOs.Requests;

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

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var userId = GetUserId();
            var user = await _userService.GetByIdAsync(userId);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userId = GetUserId();
            await _userService.DeleteAsync(userId);
            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Change(ChangeUser user)
        {
            var userId = GetUserId();
            await _userService.ChangeUserData(user, userId);
            return Ok();
        }
    }
}