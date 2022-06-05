using Doomkinn.Timesheets.Models;
using Doomkinn.Timesheets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repo;
        private readonly UserService _userService;
        public EmployeeController(EmployeeRepository employeeRepository, UserService userService)
        {
            _repo = employeeRepository;
            _userService = userService;
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
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            TokenResponse token = _userService.Authenticate(user, password);
            if (token is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }
        [Authorize]
        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = _userService.RefreshToken(oldRefreshToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
