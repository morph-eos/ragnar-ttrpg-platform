using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await context.Regions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(long id)
        {
            var region = await context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(long id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            context.Entry(region).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            context.Regions.Add(region);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.Id }, region);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(long id)
        {
            var region = await context.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            context.Regions.Remove(region);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(long id)
        {
            return context.Regions.Any(e => e.Id == id);
        }
    }
}
