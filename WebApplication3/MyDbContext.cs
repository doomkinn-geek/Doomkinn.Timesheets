using Doomkinn.Timesheets.Models;
using Microsoft.EntityFrameworkCore;

namespace Doomkinn.Timesheets
{
    public sealed class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(x => x.Comment);
        }
    }
}
