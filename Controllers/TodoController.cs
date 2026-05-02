using Microsoft.AspNetCore.Mvc;
using FirstAPI.Models;
using FirstAPI.Services;
using FirstAPI.DTOs;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService service)
        {
            _todoService = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTodos(int id)
        {
            var Todos = await _todoService.GetAllUserTodosAsync(id);
            if (Todos == null) return NotFound();
            return Ok(Todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(CreateTodoDto todo)
        {
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