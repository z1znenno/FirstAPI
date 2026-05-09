using System.ComponentModel.DataAnnotations;

namespace FirstAPI.DTOs.Requests
{
    public class ChangeUser
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [Range(0, 150)]
        public int Age { get; set; }
        [MaxLength(50)]
        public string? Login { get; set; }
    }
}