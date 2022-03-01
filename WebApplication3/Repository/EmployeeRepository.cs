using Doomkinn.Timesheets.Data.DB;
using Doomkinn.Timesheets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Repository
{
    public class EmployeeRepository
    {
        private readonly DataDBContext _context;
        public EmployeeRepository(DataDBContext context)
        {
            _context = context;
        }
        public async Task Add(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyCollection<Employee>> Get()
        {
            var result = await _context.Employees.Where(x => x.IsDeleted == false).ToListAsync();
            return result;
        }
        public async Task Update(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async void Delete(int id)
        {
            var entity = _context.Employees.Find(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
