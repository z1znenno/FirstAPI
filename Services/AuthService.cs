using FirstAPI.DTOs.Requests;
using FirstAPI.Models.Exceptions;
using FirstAPI.Services.Interfaces;

namespace FirstAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserService _service;
        private readonly JwtTokenGenerator _token;

        public AuthService(IConfiguration config, IUserService service, JwtTokenGenerator token)
        {
            _config = config;
            _service = service;
            _token = token;
        }

        public async Task<string> Login(LoginDto login)
        {
            if (login.Login == null)
                throw new ArgumentNullException(nameof(login.Login));
            var user = await _service.GetByLoginAsync(login.Login);
            var validatePassword = BCrypt.Net.BCrypt.EnhancedVerify(login.Password, user.PasswordHash);
            if (!validatePassword) throw new AuthorizeException("Wrong login or password");
            return _token.GenerateToken(user);

        }

        public async Task<string> Register(CreateUserDto userDto)
        {
            var enhancedHashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDto.Password);
            userDto.Password = enhancedHashPassword;
            var user = await _service.AddAsync(userDto);
            return _token.GenerateToken(user);
        }
    }
}