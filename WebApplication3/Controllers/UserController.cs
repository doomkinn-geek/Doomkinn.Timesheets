using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doomkinn.Timesheets.Data.DB;
using Doomkinn.Timesheets.Models;
using Doomkinn.Timesheets.Repository;

namespace Doomkinn.Timesheets.Controllers
{
    public class UserController : Controller
    {        
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {     
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var res = await _repo.Get();
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            await _repo.Add(user);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] User newUser)
        {
            await _repo.Update(newUser);
            return NoContent();
        }
        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult> Delete(int userId)
        {
            await _repo.Delete(userId);
            return NoContent();
        }
    }
}
