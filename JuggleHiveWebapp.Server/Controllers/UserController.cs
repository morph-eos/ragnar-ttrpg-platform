using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await userService.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
