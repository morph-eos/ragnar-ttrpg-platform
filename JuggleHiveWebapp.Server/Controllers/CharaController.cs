/*
 * Character Controller - Core TTRPG Character Management
 * 
 * This controller handles all HTTP requests related to character management in the TTRPG system.
 * It provides full CRUD (Create, Read, Update, Delete) operations for player characters,
 * implementing RESTful API principles for consistent and predictable endpoints.
 * 
 * Key Responsibilities:
 * - Character creation and validation
 * - Character retrieval (individual and collections)
 * - Character updates and progression tracking
 * - Character deletion and cleanup
 * 
 * API Endpoints:
 * - GET /api/chara - Retrieve all characters
 * - GET /api/chara/{id} - Retrieve specific character by ID
 * - POST /api/chara - Create new character
 * - PUT /api/chara/{id} - Update existing character
 * - DELETE /api/chara/{id} - Delete character
 * 
 * Security Note: This controller currently allows unrestricted access.
 * In production, consider adding authentication and authorization attributes.
 */

using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    /// <summary>
    /// API Controller for managing TTRPG characters
    /// Uses dependency injection to access the character service layer
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CharaController(ICharaService charaService) : ControllerBase
    {
        /// <summary>
        /// Retrieves all characters from the database
        /// GET: api/chara
        /// </summary>
        /// <returns>Collection of all characters with their basic information</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chara>>> GetCharas()
        {
            // Delegate to service layer for business logic and data access
            return Ok(await charaService.GetAllCharasAsync());
        }

        /// <summary>
        /// Retrieves a specific character by their unique identifier
        /// GET: api/chara/{id}
        /// </summary>
        /// <param name="id">Unique character identifier</param>
        /// <returns>Character data if found, 404 Not Found if character doesn't exist</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Chara>> GetChara(long id)
        {
            var chara = await charaService.GetCharaByIdAsync(id);

            // Return 404 if character not found (RESTful convention)
            if (chara == null)
            {
                return NotFound();
            }

            return chara;
        }

        /// <summary>
        /// Updates an existing character with new data
        /// PUT: api/chara/{id}
        /// </summary>
        /// <param name="id">Character ID from URL route</param>
        /// <param name="chara">Updated character data from request body</param>
        /// <returns>204 No Content on success, 400 Bad Request if ID mismatch</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChara(long id, Chara chara)
        {
            // Validate that URL ID matches the character object ID (security measure)
            if (id != chara.Id)
            {
                return BadRequest();
            }

            // Delegate update operation to service layer
            await charaService.UpdateCharaAsync(chara);
            
            // Return 204 No Content (standard for successful PUT operations)
            return NoContent();
        }

        /// <summary>
        /// Creates a new character in the system
        /// POST: api/chara
        /// </summary>
        /// <param name="chara">Character data from request body</param>
        /// <returns>201 Created with character data and location header</returns>
        [HttpPost]
        public async Task<ActionResult<Chara>> PostChara(Chara chara)
        {
            // Add character through service layer (handles validation and database operations)
            await charaService.AddCharaAsync(chara);
            
            // Return 201 Created with location header pointing to the new character
            // This follows REST conventions for resource creation
            return CreatedAtAction(nameof(GetChara), new { id = chara.Id }, chara);
        }

        /// <summary>
        /// Deletes a character from the system
        /// DELETE: api/chara/{id}
        /// </summary>
        /// <param name="id">Unique identifier of character to delete</param>
        /// <returns>204 No Content on successful deletion</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChara(long id)
        {
            // Delegate deletion to service layer (may include cascade delete operations)
            await charaService.DeleteCharaAsync(id);
            
            // Return 204 No Content (standard for successful DELETE operations)
            return NoContent();
        }
    }
}
