using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersTreePointController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharactersTreePoint>>> GetCharactersTreePoints()
        {
            return await context.CharactersTreePoints.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharactersTreePoint>> GetCharactersTreePoint(long id)
        {
            var charactersTreePoint = await context.CharactersTreePoints.FindAsync(id);

            if (charactersTreePoint == null)
            {
                return NotFound();
            }

            return charactersTreePoint;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharactersTreePoint(long id, CharactersTreePoint charactersTreePoint)
        {
            if (id != charactersTreePoint.Id)
            {
                return BadRequest();
            }

            context.Entry(charactersTreePoint).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharactersTreePointExists(id))
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
        public async Task<ActionResult<CharactersTreePoint>> PostCharactersTreePoint(CharactersTreePoint charactersTreePoint)
        {
            context.CharactersTreePoints.Add(charactersTreePoint);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCharactersTreePoint", new { id = charactersTreePoint.Id }, charactersTreePoint);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharactersTreePoint(long id)
        {
            var charactersTreePoint = await context.CharactersTreePoints.FindAsync(id);
            if (charactersTreePoint == null)
            {
                return NotFound();
            }

            context.CharactersTreePoints.Remove(charactersTreePoint);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharactersTreePointExists(long id)
        {
            return context.CharactersTreePoints.Any(e => e.Id == id);
        }
    }
}
