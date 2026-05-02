using FirstAPI.DTOs;
using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services
{
      public class UserDbService : IUserService
    {
        private readonly AppDbContext _context;
        public UserDbService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => id == x.Id);
            return user;
        }
        public async Task<CreateUserDto> AddAsync(CreateUserDto user)
        {
            await _context.Users.AddAsync(new User()
            {
                Name = user.Name,
                Age = user.Age
            });
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeUserData(int Id, string name, int age)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if(user != null) 
            {
                user.Name = name;
                user.Age = age;
            };
            await _context.SaveChangesAsync();
        }
    }       
}
