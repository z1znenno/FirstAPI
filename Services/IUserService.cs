using FirstAPI.Data;
using FirstAPI.DTOs;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(CreateUserDto user);
        Task DeleteAsync(int id);
        Task<List<User>> GetAdultsAsync();
        Task ChangeUserData(int id, string name, int age);
    }
}