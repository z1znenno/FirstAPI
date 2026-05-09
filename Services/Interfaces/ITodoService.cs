using FirstAPI.Models;
using FirstAPI.DTOs.Requests;
using FirstAPI.DTOs.Responses;

namespace FirstAPI.Services.Interfaces
{
    public interface ITodoService
    {
        Task<UserTodosDto?> GetAllUserTodosAsync(int userId);
        Task<TodoDto> AddTodoAsync(CreateTodoDto createTodo, int userId);
        Task DeleteTodoAsync(int id);
        Task MakeCompleteAsync(int todoId, int userId, bool IsCompleted);
    }
}