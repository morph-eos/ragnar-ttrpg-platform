using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseStatController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseStat>>> GetBaseStats()
        {
            return await context.BaseStats.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseStat>> GetBaseStat(long id)
        {
            var baseStat = await context.BaseStats.FindAsync(id);

            if (baseStat == null)
            {
                return NotFound();
            }

            return baseStat;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseStat(long id, BaseStat baseStat)
        {
            if (id != baseStat.Id)
            {
                return BadRequest();
            }

            context.Entry(baseStat).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseStatExists(id))
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
        public async Task<ActionResult<BaseStat>> PostBaseStat(BaseStat baseStat)
        {
            context.BaseStats.Add(baseStat);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBaseStat", new { id = baseStat.Id }, baseStat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseStat(long id)
        {
            var baseStat = await context.BaseStats.FindAsync(id);
            if (baseStat == null)
            {
                return NotFound();
            }

            context.BaseStats.Remove(baseStat);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseStatExists(long id)
        {
            return context.BaseStats.Any(e => e.Id == id);
        }
    }
}
