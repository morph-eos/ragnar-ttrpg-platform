using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillFamilyController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillFamily>>> GetSkillFamilies()
        {
            return await context.SkillFamilies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillFamily>> GetSkillFamily(long id)
        {
            var skillFamily = await context.SkillFamilies.FindAsync(id);

            if (skillFamily == null)
            {
                return NotFound();
            }

            return skillFamily;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillFamily(long id, SkillFamily skillFamily)
        {
            if (id != skillFamily.Id)
            {
                return BadRequest();
            }

            context.Entry(skillFamily).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillFamilyExists(id))
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
        public async Task<ActionResult<SkillFamily>> PostSkillFamily(SkillFamily skillFamily)
        {
            context.SkillFamilies.Add(skillFamily);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSkillFamily", new { id = skillFamily.Id }, skillFamily);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillFamily(long id)
        {
            var skillFamily = await context.SkillFamilies.FindAsync(id);
            if (skillFamily == null)
            {
                return NotFound();
            }

            context.SkillFamilies.Remove(skillFamily);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillFamilyExists(long id)
        {
            return context.SkillFamilies.Any(e => e.Id == id);
        }
    }
}
