using Doomkinn.Timesheets.Models;
using System.Data.Entity;

namespace Doomkinn.Timesheets.Data.DB
{
    public class DataDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DataDBContext(string connectionString):base(connectionString)  
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
