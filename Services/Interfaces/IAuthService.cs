using FirstAPI.DTOs;

namespace FirstAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task Login(LoginDto login);
        Task Register(CreateUserDto user);
    }
}