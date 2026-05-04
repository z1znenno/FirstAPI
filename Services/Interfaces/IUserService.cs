using FirstAPI.DTOs;
using FirstAPI.Models;

namespace FirstAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<CreateUserDto> AddAsync(CreateUserDto user);
        Task DeleteAsync(int id);
        Task ChangeUserData(int id, string name, int age);
    }
}