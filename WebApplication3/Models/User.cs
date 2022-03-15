using System.ComponentModel.DataAnnotations.Schema;

namespace Doomkinn.Timesheets.Models
{
    [Table("User", Schema = "Test")]
    public sealed class User 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }

}
