using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doomkinn.Timesheets.Models
{
    [Table("User", Schema = "Test")]
    public sealed class User 
    {
        [Required]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
