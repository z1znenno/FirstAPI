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

        [HttpGet]
        public async Task<IActionResult> GetUserTodos()
        {
            _logger.LogInformation("Getting all user todos...");
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var Todos = await _todoService.GetAllUserTodosAsync(userId);
            return Ok(Todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(CreateTodoDto todo)
        {
            _logger.LogInformation("Adding new todo");
            var createdTodo = await _todoService.AddTodoAsync(todo);
            return Ok(createdTodo);
        }

        [HttpPatch]
        public async Task<IActionResult> MakeComplete(int todoId, bool IsComplete)
        {
            await _todoService.MakeCompleteAsync(todoId, IsComplete);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo(int todoId)
        {
            await _todoService.DeleteTodoAsync(todoId);
            return NoContent();
        }
    }
}