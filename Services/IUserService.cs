using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task DeleteAsync(int id);
        Task<List<User>> GetAdultsAsync();
    }

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Name = "John Doe",
                Age = 30
            }
        };

        public Task<List<User>> GetAllAsync() =>
            Task.FromResult(_users);

        public Task<User?> GetByIdAsync(int id) =>
            Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null) _users.Remove(user);
            return Task.CompletedTask;
        }
        public Task<List<User>> GetAdultsAsync()
        {
            return Task.FromResult(_users.Where(x => x.Age >= 18).ToList());
        }
    }

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
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
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
    }       
}