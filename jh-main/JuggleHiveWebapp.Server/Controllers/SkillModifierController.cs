using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillModifierController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillModifier>>> GetSkillModifiers()
        {
            return await context.SkillModifiers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillModifier>> GetSkillModifier(long id)
        {
            var skillModifier = await context.SkillModifiers.FindAsync(id);

            if (skillModifier == null)
            {
                return NotFound();
            }

            return skillModifier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillModifier(long id, SkillModifier skillModifier)
        {
            if (id != skillModifier.Id)
            {
                return BadRequest();
            }

            context.Entry(skillModifier).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillModifierExists(id))
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
        public async Task<ActionResult<SkillModifier>> PostSkillModifier(SkillModifier skillModifier)
        {
            context.SkillModifiers.Add(skillModifier);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSkillModifier", new { id = skillModifier.Id }, skillModifier);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillModifier(long id)
        {
            var skillModifier = await context.SkillModifiers.FindAsync(id);
            if (skillModifier == null)
            {
                return NotFound();
            }

            context.SkillModifiers.Remove(skillModifier);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillModifierExists(long id)
        {
            return context.SkillModifiers.Any(e => e.Id == id);
        }
    }
}
