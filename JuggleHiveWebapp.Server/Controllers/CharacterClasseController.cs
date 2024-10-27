using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using JuggleHiveWebapp.Server.Services;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClasseController(ICharacterClassService characterClassService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterClass>>> GetCharacterClasses()
        {
            return Ok(await characterClassService.GetAllCharacterClassesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterClass>> GetCharacterClass(long id)
        {
            var characterClass = await characterClassService.GetCharacterClassByIdAsync(id);

            if (characterClass == null)
            {
                return NotFound();
            }

            return characterClass;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterClass(long id, CharacterClass characterClass)
        {
            if (id != characterClass.Id)
            {
                return BadRequest();
            }

            await characterClassService.UpdateCharacterClassAsync(characterClass);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CharacterClass>> PostCharacterClass(CharacterClass characterClass)
        {
            await characterClassService.AddCharacterClassAsync(characterClass);
            return CreatedAtAction(nameof(GetCharacterClass), new { id = characterClass.Id }, characterClass);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterClass(long id)
        {
            await characterClassService.DeleteCharacterClassAsync(id);
            return NoContent();
        }
    }
}
