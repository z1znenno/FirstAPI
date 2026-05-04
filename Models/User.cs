using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();
        public string? Login { get; set; }
        public string? PasswordHash { get; set; }
    }
}