using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.DTOs
{
    public class CreateTodoDto
    {
        [MaxLength(50)]
        [Required]
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        [Required]
        public int UserId { get; set; }
    }
}