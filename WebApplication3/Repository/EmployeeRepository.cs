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
            var dbEntity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == entity.Id);
            dbEntity.IsDeleted = entity.IsDeleted;
            dbEntity.Comment = entity.Comment;
            dbEntity.EmployeeName = entity.EmployeeName;
            dbEntity.Email = entity.Email;
            dbEntity.Age = entity.Age;
            dbEntity.MobileNumber = entity.MobileNumber;
            dbEntity.Salary = entity.Salary;
            dbEntity.Token = entity.Token;
            _context.Update(dbEntity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = _context.Employees.Find(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }        
        public Employee GetByToken(string token)
        {
            return _context.Employees.FirstOrDefault(e => e.Token == token);
        }
    }
}
