using Microsoft.AspNetCore.Mvc;
using FirstAPI.Services.Interfaces;
using FirstAPI.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace FirstAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService service, ILogger<TodoController> logger)
        {
            _todoService = service;
            _logger = logger;
        }

        public int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTodos()
        {
            _logger.LogInformation("Getting all user todos...");
            var userId = GetUserId();
            var Todos = await _todoService.GetAllUserTodosAsync(userId);
            return Ok(Todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(CreateTodoDto todo)
        {
            _logger.LogInformation("Adding new todo");
            var userId = GetUserId();
            var createdTodo = await _todoService.AddTodoAsync(todo, userId);
            return Ok(createdTodo);
        }

        [HttpPatch("{todoId}")]
        public async Task<IActionResult> MakeComplete(int todoId, bool IsComplete)
        {
            var userId = GetUserId();
            await _todoService.MakeCompleteAsync(todoId, userId, IsComplete);
            return Ok();
        }

        [HttpDelete("{todoId}")]
        public async Task<IActionResult> DeleteTodo(int todoId)
        {
            await _todoService.DeleteTodoAsync(todoId);
            return NoContent();
        }
    }
}