using FirstAPI.DTOs.Requests;
using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;
using FirstAPI.Models.Exceptions;
using FirstAPI.Services.Interfaces;
using FirstAPI.DTOs.Responses;


namespace FirstAPI.Services
{
      public class UserDbService : IUserService
    {
        private readonly AppDbContext _context;
        public UserDbService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<UserResponseDto> GetByIdAsync(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id)
            .Select(u => new UserResponseDto(
            
                name : u.Name ?? string.Empty,
                age : u.Age,
                todos : u.Todos.Select(t => new TodoDto(
                    id : t.Id,
                    title : t.Title!,
                    isComplete : t.IsCompleted
                )).ToList(),
                login : u.Login ?? string.Empty
            
            )).FirstOrDefaultAsync();
            if (user == null) throw new NotFoundException("User not found");
            return user;
        }

        public async Task<UserDto> GetByLoginAsync(string login)
        {
            var user = await _context.Users.Where(u => u.Login == login)
            .Select(u => new UserDto(
                id : u.Id,
                name : u.Name ?? string.Empty,
                age : u.Age,
                todos : u.Todos.Select(t => new TodoDto(
                    id : t.Id,
                    title : t.Title!,
                    isComplete : t.IsCompleted
                )).ToList(),
                login : u.Login ?? string.Empty,
                passwordHash : u.PasswordHash ?? string.Empty
            
            )).FirstOrDefaultAsync();
            if (user == null) throw new AuthorizeException("Wrong login or password");
            return user;
        }
        public async Task<UserDto> AddAsync(CreateUserDto user)
        {
            var entity = new User()
            {
                Name = user.Name,
                Age = user.Age,
                Login = user.Login,
                PasswordHash = user.Password
            };
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            var userDto = new UserDto(entity.Id, entity.Name!, entity.Age, entity.Todos.Select(t => new TodoDto
            (
                id : t.Id,
                title : t.Title!,
                isComplete : t.IsCompleted
            )).ToList(), entity.Login!, entity.PasswordHash!);
            return userDto;
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new NotFoundException("User not found"); 
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeUserData(ChangeUser changeUser, int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user == null) throw new NotFoundException("User not found");
            user.Name = changeUser.Name;
            user.Age = changeUser.Age;
            user.Login = changeUser.Login;
            await _context.SaveChangesAsync();
        }
    }       
}
