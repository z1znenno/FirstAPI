using FirstAPI.DTOs.Requests;

namespace FirstAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto login);
        Task<string> Register(CreateUserDto user);
    }
}