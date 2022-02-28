using System.ComponentModel.DataAnnotations.Schema;

namespace Doomkinn.Timesheets.Models
{
    [Table("Employee", Schema = "Test")]
    public sealed class Employee
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
