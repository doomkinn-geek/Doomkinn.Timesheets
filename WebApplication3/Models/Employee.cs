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
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public string Token { get; set; }
    }
}
