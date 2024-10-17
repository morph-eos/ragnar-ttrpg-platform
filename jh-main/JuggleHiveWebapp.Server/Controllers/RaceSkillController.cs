using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceSkillController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceSkill>>> GetRaceSkills()
        {
            return await context.RaceSkills.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceSkill>> GetRaceSkill(long id)
        {
            var raceSkill = await context.RaceSkills.FindAsync(id);

            if (raceSkill == null)
            {
                return NotFound();
            }

            return raceSkill;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceSkill(long id, RaceSkill raceSkill)
        {
            if (id != raceSkill.Id)
            {
                return BadRequest();
            }

            context.Entry(raceSkill).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceSkillExists(id))
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
        public async Task<ActionResult<RaceSkill>> PostRaceSkill(RaceSkill raceSkill)
        {
            context.RaceSkills.Add(raceSkill);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRaceSkill", new { id = raceSkill.Id }, raceSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceSkill(long id)
        {
            var raceSkill = await context.RaceSkills.FindAsync(id);
            if (raceSkill == null)
            {
                return NotFound();
            }

            context.RaceSkills.Remove(raceSkill);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceSkillExists(long id)
        {
            return context.RaceSkills.Any(e => e.Id == id);
        }
    }
}
