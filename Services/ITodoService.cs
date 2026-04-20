using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;
using FirstAPI.DTOs;

namespace FirstAPI.Services
{
    public interface ITodoService
    {
        Task<UserTodosDto> GetAllUserTodosAsync(int userId);
        Task AddTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
        Task MakeCompleteAsync(int id, bool IsCompleted);
    }
}