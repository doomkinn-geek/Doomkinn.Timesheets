using Doomkinn.Timesheets.Models;
using Doomkinn.Timesheets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repo;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _repo = employeeRepository;
        }        
        [HttpGet("all")]
        public async Task<ActionResult<Employee>> GetAll()
        {
            var res = await _repo.Get();
            return Ok(res);
        }
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Employee employee)
        {
            await _repo.Add(employee);
            return NoContent();
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] Employee newEmployee)
        {
            await _repo.Update(newEmployee);
            return NoContent();
        }
        [HttpDelete]
        [Route("{employeeId}")]
        public async Task<ActionResult> Delete(int employeeId)
        {
            await _repo.Delete(employeeId);
            return NoContent();
        }        
    }
}
