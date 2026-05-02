using FirstAPI.DTOs;
using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;

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
                {
                    Title = t.Title,
                    IsCompleted = t.IsCompleted
                }).ToList()
            }
            ).FirstOrDefaultAsync();
            
            // var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            // if (user == null) return null; 
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
        public async Task<Todo> AddTodoAsync(CreateTodoDto todo)
        {
            var entity = new Todo()
            {
                Title = todo.Title,
                UserId = todo.UserId,
                IsCompleted = false
            };
            await _context.Todos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo != null) _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
        public async Task MakeCompleteAsync(int id, bool IsCompleted)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if(todo != null) todo.IsCompleted = IsCompleted;
            await _context.SaveChangesAsync();
        }
    }
}