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

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.ToListAsync ();
        
        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => id == x.Id);
            return user;
        }
        public async Task AddAsync(CreateUserDto user)
        {
            await _context.Users.AddAsync(new User()
            {
                Name = user.Name,
                Age = user.Age
            });
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<User>> GetAdultsAsync()
        {
            return await _context.Users.Where(x => x.Age >= 18).ToListAsync();
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
