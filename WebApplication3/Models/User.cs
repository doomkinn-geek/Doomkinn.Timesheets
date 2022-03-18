using System.ComponentModel.DataAnnotations.Schema;

namespace Doomkinn.Timesheets.Models
{
    [Table("User", Schema = "Test")]
    public sealed class User 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
