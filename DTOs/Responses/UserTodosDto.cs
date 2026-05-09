namespace FirstAPI.DTOs.Responses
{
    public class UserTodosDto
    {
        public string? UserName{ get; set; }
        public List<TodoDto> Todos { get; set; } = new List<TodoDto>();
    }
}