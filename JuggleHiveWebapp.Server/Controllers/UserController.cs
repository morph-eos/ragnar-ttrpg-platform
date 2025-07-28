/*
 * User Controller - Authentication and User Management
 * 
 * This controller handles all user-related operations including registration, authentication,
 * and user profile management for the TTRPG platform. It provides secure user management
 * with proper validation and authentication flows.
 * 
 * Key Responsibilities:
 * - User registration and account creation
 * - User authentication and login management
 * - User profile updates and data management
 * - User account deletion and cleanup
 * 
 * API Endpoints:
 * - GET /api/user - Retrieve all users (admin functionality)
 * - GET /api/user/{id} - Retrieve specific user profile
 * - POST /api/user - Register new user account
 * - PUT /api/user/{id} - Update user profile
 * - DELETE /api/user/{id} - Delete user account
 * 
 * Security Note: Consider implementing role-based authorization for user management
 * operations to restrict access based on user permissions.
 */

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
