using System.ComponentModel.DataAnnotations;

namespace FirstAPI.DTOs
{
    public class CreateUserDto
    {
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [Range(0, 150)]
        public int Age { get; set; }
    }
}