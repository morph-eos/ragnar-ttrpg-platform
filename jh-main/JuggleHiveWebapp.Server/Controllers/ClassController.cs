using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return await context.Classes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(long id)
        {
            var @class = await context.Classes.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(long id, Class @class)
        {
            if (id != @class.Id)
            {
                return BadRequest();
            }

            context.Entry(@class).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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
        public async Task<ActionResult<Class>> PostClass(Class @class)
        {
            context.Classes.Add(@class);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.Id }, @class);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(long id)
        {
            var @class = await context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            context.Classes.Remove(@class);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(long id)
        {
            return context.Classes.Any(e => e.Id == id);
        }
    }
}
