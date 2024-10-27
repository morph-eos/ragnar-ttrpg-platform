using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterSkillController(ICharacterSkillService characterSkillService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterSkill>>> GetCharacterSkills()
        {
            return Ok(await characterSkillService.GetAllCharacterSkillsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterSkill>> GetCharacterSkill(long id)
        {
            var characterSkill = await characterSkillService.GetCharacterSkillByIdAsync(id);

            if (characterSkill == null)
            {
                return NotFound();
            }

            return characterSkill;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterSkill(long id, CharacterSkill characterSkill)
        {
            if (id != characterSkill.Id)
            {
                return BadRequest();
            }

            await characterSkillService.UpdateCharacterSkillAsync(characterSkill);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CharacterSkill>> PostCharacterSkill(CharacterSkill characterSkill)
        {
            await characterSkillService.AddCharacterSkillAsync(characterSkill);
            return CreatedAtAction(nameof(GetCharacterSkill), new { id = characterSkill.Id }, characterSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterSkill(long id)
        {
            await characterSkillService.DeleteCharacterSkillAsync(id);
            return NoContent();
        }
    }
}
