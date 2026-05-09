using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.DTOs.Requests
{
    public class CreateTodoDto
    {
        [MaxLength(1000)]
        [Required]
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}