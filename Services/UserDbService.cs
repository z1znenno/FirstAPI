using FirstAPI.DTOs;
using FirstAPI.Models;
using FirstAPI.Data;
using Microsoft.EntityFrameworkCore;
using FirstAPI.Models.Exceptions;
using FirstAPI.Services.Interfaces;


namespace FirstAPI.Services
{
      public class UserDbService : IUserService
    {
        private readonly AppDbContext _context;
        public UserDbService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => id == x.Id);
            if (user == null) throw new NotFoundException("User not found");
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
            if (user == null) throw new NotFoundException("User not found"); 
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeUserData(int Id, string name, int age)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if(user == null) throw new NotFoundException("User not found");
            user.Name = name;
            user.Age = age;
            await _context.SaveChangesAsync();
        }
    }       
}
