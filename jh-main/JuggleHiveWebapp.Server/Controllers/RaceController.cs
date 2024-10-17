using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
        {
            return await context.Races.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(long id)
        {
            var race = await context.Races.FindAsync(id);

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(long id, Race race)
        {
            if (id != race.Id)
            {
                return BadRequest();
            }

            context.Entry(race).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
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
        public async Task<ActionResult<Race>> PostRace(Race race)
        {
            context.Races.Add(race);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRace", new { id = race.Id }, race);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(long id)
        {
            var race = await context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            context.Races.Remove(race);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceExists(long id)
        {
            return context.Races.Any(e => e.Id == id);
        }
    }
}
