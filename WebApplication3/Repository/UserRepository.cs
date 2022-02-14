using Doomkinn.Timesheets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Repository
{
    public class UserRepository
    {
        private MyDbContext _dbContext;
        public UserRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public async Task Add(User entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> Get()
        {
            var q = _dbContext.Users.
        }

        public async void Update(User entity)
        {
            var dbEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;    
            dbEntity.MiddleName = entity.MiddleName;
            dbEntity.IsDeleted = entity.IsDeleted;
            entity.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = _dbContext.Users.Find(id);
            entity.IsDeleted = true;
            await _dbContext.SaveChangesAsync();   
        }
    }
}
