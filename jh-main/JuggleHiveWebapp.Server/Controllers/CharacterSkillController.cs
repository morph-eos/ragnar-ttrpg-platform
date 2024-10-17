using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterSkillController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterSkill>>> GetCharacterSkills()
        {
            return await context.CharacterSkills.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterSkill>> GetCharacterSkill(long id)
        {
            var characterSkill = await context.CharacterSkills.FindAsync(id);

            if (characterSkill == null)
            {
                return NotFound();
            }

            return characterSkill;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterSkill(long id, CharacterSkill characterSkill)
        {
            if (id != characterSkill.Id)
            {
                return BadRequest();
            }

            context.Entry(characterSkill).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterSkillExists(id))
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
        public async Task<ActionResult<CharacterSkill>> PostCharacterSkill(CharacterSkill characterSkill)
        {
            context.CharacterSkills.Add(characterSkill);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterSkill", new { id = characterSkill.Id }, characterSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterSkill(long id)
        {
            var characterSkill = await context.CharacterSkills.FindAsync(id);
            if (characterSkill == null)
            {
                return NotFound();
            }

            context.CharacterSkills.Remove(characterSkill);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterSkillExists(long id)
        {
            return context.CharacterSkills.Any(e => e.Id == id);
        }
    }
}
