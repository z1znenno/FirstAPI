using FirstAPI.Models;
using FirstAPI.DTOs;

namespace FirstAPI.Services.Interfaces
{
    public interface ITodoService
    {
        Task<UserTodosDto?> GetAllUserTodosAsync(int userId);
        Task<Todo> AddTodoAsync(CreateTodoDto todo);
        Task DeleteTodoAsync(int id);
        Task MakeCompleteAsync(int id, bool IsCompleted);
    }
}