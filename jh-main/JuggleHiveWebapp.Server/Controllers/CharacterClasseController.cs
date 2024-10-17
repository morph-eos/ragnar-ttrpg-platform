using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClasseController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterClass>>> GetCharacterClasses()
        {
            return await context.CharacterClasses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterClass>> GetCharacterClass(long id)
        {
            var characterClass = await context.CharacterClasses.FindAsync(id);

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

            context.Entry(characterClass).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CharacterClass>> PostCharacterClass(CharacterClass characterClass)
        {
            context.CharacterClasses.Add(characterClass);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterClass", new { id = characterClass.Id }, characterClass);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterClass(long id)
        {
            var characterClass = await context.CharacterClasses.FindAsync(id);
            if (characterClass == null)
            {
                return NotFound();
            }

            context.CharacterClasses.Remove(characterClass);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterClassExists(long id)
        {
            return context.CharacterClasses.Any(e => e.Id == id);
        }
    }
}
