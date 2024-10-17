using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillModifierDixController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillModifierDix>>> GetSkillModifierDices()
        {
            return await context.SkillModifierDices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillModifierDix>> GetSkillModifierDix(long id)
        {
            var skillModifierDix = await context.SkillModifierDices.FindAsync(id);

            if (skillModifierDix == null)
            {
                return NotFound();
            }

            return skillModifierDix;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillModifierDix(long id, SkillModifierDix skillModifierDix)
        {
            if (id != skillModifierDix.Id)
            {
                return BadRequest();
            }

            context.Entry(skillModifierDix).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillModifierDixExists(id))
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
        public async Task<ActionResult<SkillModifierDix>> PostSkillModifierDix(SkillModifierDix skillModifierDix)
        {
            context.SkillModifierDices.Add(skillModifierDix);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSkillModifierDix", new { id = skillModifierDix.Id }, skillModifierDix);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillModifierDix(long id)
        {
            var skillModifierDix = await context.SkillModifierDices.FindAsync(id);
            if (skillModifierDix == null)
            {
                return NotFound();
            }

            context.SkillModifierDices.Remove(skillModifierDix);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillModifierDixExists(long id)
        {
            return context.SkillModifierDices.Any(e => e.Id == id);
        }
    }
}
