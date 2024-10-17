using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterInfoController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterInfo>>> GetCharacterInfos()
        {
            return await context.CharacterInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterInfo>> GetCharacterInfo(long id)
        {
            var characterInfo = await context.CharacterInfos.FindAsync(id);

            if (characterInfo == null)
            {
                return NotFound();
            }

            return characterInfo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterInfo(long id, CharacterInfo characterInfo)
        {
            if (id != characterInfo.Id)
            {
                return BadRequest();
            }

            context.Entry(characterInfo).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterInfoExists(id))
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
        public async Task<ActionResult<CharacterInfo>> PostCharacterInfo(CharacterInfo characterInfo)
        {
            context.CharacterInfos.Add(characterInfo);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterInfo", new { id = characterInfo.Id }, characterInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterInfo(long id)
        {
            var characterInfo = await context.CharacterInfos.FindAsync(id);
            if (characterInfo == null)
            {
                return NotFound();
            }

            context.CharacterInfos.Remove(characterInfo);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterInfoExists(long id)
        {
            return context.CharacterInfos.Any(e => e.Id == id);
        }
    }
}
