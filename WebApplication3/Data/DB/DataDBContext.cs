using Doomkinn.Timesheets.Models;
using Microsoft.EntityFrameworkCore;

namespace Doomkinn.Timesheets.Data.DB
{
    public class DataDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DataDBContext(DbContextOptions options) : base(options) {}        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Ignore(x => x.Comment);
            modelBuilder.Entity<User>().Ignore(x => x.Comment);
        }
    }
}
