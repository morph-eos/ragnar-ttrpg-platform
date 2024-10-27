using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharaController(ICharaService charaService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chara>>> GetCharas()
        {
            return Ok(await charaService.GetAllCharasAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chara>> GetChara(long id)
        {
            var chara = await charaService.GetCharaByIdAsync(id);

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

            await charaService.UpdateCharaAsync(chara);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Chara>> PostChara(Chara chara)
        {
            await charaService.AddCharaAsync(chara);
            return CreatedAtAction(nameof(GetChara), new { id = chara.Id }, chara);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChara(long id)
        {
            await charaService.DeleteCharaAsync(id);
            return NoContent();
        }
    }
}
