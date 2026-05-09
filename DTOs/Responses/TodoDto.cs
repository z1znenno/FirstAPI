

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace FirstAPI.DTOs.Responses
{
    public class TodoDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

        public TodoDto(int id, string title, bool isComplete)
        {
            Id = id;
            Title = title;
            IsCompleted = isComplete;
        }
    }
}