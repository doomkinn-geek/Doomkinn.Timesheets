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
            return result;
        }
        public async Task Update(User entity)
        {
            var dbEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);

            dbEntity.IsDeleted = entity.IsDeleted;
            dbEntity.LastName = entity.LastName;
            dbEntity.FirstName = entity.FirstName;
            dbEntity.MiddleName = entity.MiddleName;            
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = _context.Users.Find(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
