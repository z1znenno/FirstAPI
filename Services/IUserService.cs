using FirstAPI.Data;
using FirstAPI.DTOs;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task<CreateUserDto> AddAsync(CreateUserDto user);
        Task DeleteAsync(int id);
        Task ChangeUserData(int id, string name, int age);
    }
}