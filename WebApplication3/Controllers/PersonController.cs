using Doomkinn.Timesheets.Models;
using Doomkinn.Timesheets.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doomkinn.Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _repo;
        public PersonController(PersonRepository personRepository)
        {
            _repo = personRepository;
        }
        [HttpGet("persons/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _repo.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("persons")]
        public IActionResult Get(int skip, int take)
        {
            var result = _repo.Get(skip, take);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("persons/search")]
        public IActionResult Get(string searchTerm)
        {
            var result = _repo.Get(searchTerm);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("register")]
        public IActionResult RegisterPerson([FromBody] Person personRequest)
        {
            _repo.Add(personRequest);
            return Ok();
        }
        [HttpPut("persons")]
        public IActionResult EditPerson([FromBody] Person personRequest)
        {
            _repo.Update(personRequest);
            return Ok();
        }
        [HttpDelete("persons/{id}")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
