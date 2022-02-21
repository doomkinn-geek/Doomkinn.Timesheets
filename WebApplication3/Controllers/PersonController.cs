using Doomkinn.Timesheets.Models;
using Doomkinn.Timesheets.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Doomkinn.Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;
        public PersonController(PersonRepository personRepository)
        {
            _repo = personRepository;
        }
        //В комментарии в пул реквесте вы писали:
        //"ActionResult параметризарованный более наглядно выглядит"
        //не совсем понял. Поясните, пожалуйста
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
                return NotFound();
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
                List<Person> people = new List<Person>();
                return Ok(people);
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
                List<Person> people = new List<Person>();
                return Ok(people);
            }
        }
        [HttpPost("register")]
        public IActionResult RegisterPerson([FromBody] Person personRequest)
        {
            if(_repo.Add(personRequest) != null)
            { 
                return Ok(); 
            }
            else
            {
                return BadRequest("Запись с данным ID уже существует. Измените запрос");
            }            
        }
        [HttpPut("persons")]
        public IActionResult EditPerson([FromBody] Person personRequest)
        {
            if (_repo.Get(personRequest.Id) != null)
            {
                _repo.Update(personRequest);
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpDelete("persons/{id}")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            if (_repo.Get(id) != null)
            {
                _repo.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
