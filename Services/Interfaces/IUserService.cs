using FirstAPI.DTOs.Responses;
using FirstAPI.DTOs.Requests;

namespace FirstAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<UserDto> GetByLoginAsync(string login);
        Task<UserDto> AddAsync(CreateUserDto user);
        Task DeleteAsync(int id);
        Task ChangeUserData(int id, string name, int age, string login);
    }
}