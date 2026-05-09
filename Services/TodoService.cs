using FirstAPI.DTOs.Responses;
using FirstAPI.DTOs.Requests;
using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;
using FirstAPI.Models.Exceptions;
using FirstAPI.Services.Interfaces;

namespace FirstAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTodosDto?> GetAllUserTodosAsync(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId)
            .Select(u => new UserTodosDto
            {
                UserName = u.Name,
                Todos = u.Todos.Select(t => new TodoDto
                (
                    id : t.Id,
                    title : t.Title!,
                    isComplete : t.IsCompleted
                )).ToList()
            }
            ).FirstOrDefaultAsync();
            
            // var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            // if (user == null) throw new NotFoundException("User not found"); 
            // var todos = await _context.Todos.Where(x => x.UserId == userId).Select(t => new TodoDto
            // ()
            // {
            //     Title = t.Title,
            //     IsCompleted = t.IsCompleted
            // }).ToListAsync();
            // return new UserTodosDto()
            // {
            //     UserName = user.Name,
            //     Todos = todos
            // };
        }
        public async Task<TodoDto> AddTodoAsync(CreateTodoDto createTodo, int userId)
        {
            var entity = new Todo()
            {
                Title = createTodo.Title,
                UserId = userId,
                IsCompleted = false
            };
            await _context.Todos.AddAsync(entity);
            await _context.SaveChangesAsync();
            var todo = new TodoDto(entity.Id, entity.Title!, entity.IsCompleted);
            return todo;
        }
        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null) throw new NotFoundException("Todo not found");
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
        public async Task MakeCompleteAsync(int todoId, int userId, bool IsCompleted)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todoId);
            if(todo == null) throw new NotFoundException("Todo not found");
            if (todo.UserId != userId) throw new Exception("Not user's todo");
            todo.IsCompleted = IsCompleted;
            await _context.SaveChangesAsync();
        }
    }
}