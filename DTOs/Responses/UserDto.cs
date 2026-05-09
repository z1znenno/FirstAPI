using FirstAPI.Models;

namespace FirstAPI.DTOs.Responses
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<TodoDto> Todos { get; set; } = new List<TodoDto>();
        public string? Login { get; set; }
        public string? PasswordHash { get; set; }
        
        public UserDto(int id, string name, int age, List<TodoDto> todos, string login, string passwordHash)
        {
            Id = id;
            Name = name;
            Age = age;
            Todos = todos;
            Login = login;
            PasswordHash = passwordHash;
        }
    }
}