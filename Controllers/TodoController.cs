using Microsoft.AspNetCore.Mvc;
using FirstAPI.Services.Interfaces;
using FirstAPI.DTOs;


namespace FirstAPI.Controllers
{
    [ApiController]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTodos(int id)
        {
            _logger.LogInformation("Getting all user todos...");
            var Todos = await _todoService.GetAllUserTodosAsync(id);
            return Ok(Todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(CreateTodoDto todo)
        {
            _logger.LogInformation("Adding new todo");
            var createdTodo = await _todoService.AddTodoAsync(todo);
            return Ok(createdTodo);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MakeComplete(int id, bool IsComplete)
        {
            await _todoService.MakeCompleteAsync(id, IsComplete);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
}