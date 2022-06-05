using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doomkinn.Timesheets.Models
{
    [Table("Employee", Schema = "Test")]
    public sealed class Employee
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Range(18, 120, ErrorMessage = "Возраст должен быть более 18")]
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public string Token { get; set; }
    }
}
