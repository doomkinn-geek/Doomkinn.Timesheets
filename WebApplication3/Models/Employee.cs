namespace Doomkinn.Timesheets.Models
{
    public class Employee : BaseModel
    {
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
