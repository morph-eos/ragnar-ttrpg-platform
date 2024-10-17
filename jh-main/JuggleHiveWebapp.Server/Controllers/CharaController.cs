using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharaController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chara>>> GetCharas()
        {
            return await context.Charas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chara>> GetChara(long id)
        {
            var chara = await context.Charas.FindAsync(id);

            if (chara == null)
            {
                return NotFound();
            }

            return chara;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChara(long id, Chara chara)
        {
            if (id != chara.Id)
            {
                return BadRequest();
            }

            context.Entry(chara).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharaExists(id))
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
        public async Task<ActionResult<Chara>> PostChara(Chara chara)
        {
            context.Charas.Add(chara);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetChara", new { id = chara.Id }, chara);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChara(long id)
        {
            var chara = await context.Charas.FindAsync(id);
            if (chara == null)
            {
                return NotFound();
            }

            context.Charas.Remove(chara);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharaExists(long id)
        {
            return context.Charas.Any(e => e.Id == id);
        }
    }
}
