using Microsoft.AspNetCore.Mvc;
using FirstAPI.Models;
using FirstAPI.Services;
using FirstAPI.DTOs;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
  
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDto user)
        {
            var createdUser = await _userService.AddAsync(user);
            return Ok(createdUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Change(int id, string name, int age)
        {
            await _userService.ChangeUserData(id, name, age);
            return Ok();
        }
    }
}