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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Doomkinn.Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly UserRepository _repo;
        private readonly UserService _userService;

        public UserController(UserRepository repo, UserService userService)
        {     
            _repo = repo;
            _userService = userService;
        }
        [HttpGet("all")]
        public async Task<ActionResult<User>> GetAll()
        {
            var res = await _repo.Get();
            return Ok(res);
        }
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            await _repo.Add(user);
            return NoContent();
        }
        [HttpPut("update")]
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
