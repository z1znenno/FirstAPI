using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodosAsync(int userId);
        Task AddTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
        Task MakeCompleteAsync(int id, bool IsCompleted);
    }

    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllTodosAsync(int userId)
        {
            return await _context.Todos.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task AddTodoAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
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