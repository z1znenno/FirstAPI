using System.ComponentModel.DataAnnotations;

namespace FirstAPI.DTOs.Requests
{
    public class LoginDto
    {
        [Required]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}