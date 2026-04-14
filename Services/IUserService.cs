using FirstApi.Models;

namespace FirstApi.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task DeleteAsync(int id);
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
    }
}