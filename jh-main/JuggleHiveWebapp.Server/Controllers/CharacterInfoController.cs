using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterInfoController(ICharacterInfoService characterInfoService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterInfo>>> GetCharacterInfos()
        {
            return Ok(await characterInfoService.GetAllCharacterInfosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterInfo>> GetCharacterInfo(long id)
        {
            var characterInfo = await characterInfoService.GetCharacterInfoByIdAsync(id);

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

            await characterInfoService.UpdateCharacterInfoAsync(characterInfo);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CharacterInfo>> PostCharacterInfo(CharacterInfo characterInfo)
        {
            await characterInfoService.AddCharacterInfoAsync(characterInfo);
            return CreatedAtAction(nameof(GetCharacterInfo), new { id = characterInfo.Id }, characterInfo);
        }

    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterInfo(long id)
        {
            await characterInfoService.DeleteCharacterInfoAsync(id);
            return NoContent();
        }
    }
}
