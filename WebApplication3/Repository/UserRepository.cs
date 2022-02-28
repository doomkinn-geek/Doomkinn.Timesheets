using Doomkinn.Timesheets.Data.DB;
using Doomkinn.Timesheets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Repository
{
    public sealed class UserRepository
    {
        private readonly DataDBContext _context;
        public UserRepository(DataDBContext context)
        {
            _context = context;
        }
        public async Task Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyCollection<User>> Get()
        {
            var result = await _context.Users.Where(x => x.IsDeleted == false).ToListAsync();
        }
        public async Task Update(User entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
