namespace FirstAPI.DTOs.Responses
{
    public class UserResponseDto
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<TodoDto> Todos { get; set; } = new List<TodoDto>();
        public string? Login { get; set; }        
        public UserResponseDto(string name, int age, List<TodoDto> todos, string login)
        {
            Name = name;
            Age = age;
            Todos = todos;
            Login = login;
        }
    }
}