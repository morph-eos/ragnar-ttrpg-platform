using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillModifierController(ISkillModifierService skillModifierService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillModifier>>> GetSkillModifiers()
        {
            return Ok(await skillModifierService.GetAllSkillModifiersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillModifier>> GetSkillModifier(long id)
        {
            var skillModifier = await skillModifierService.GetSkillModifierByIdAsync(id);
            if (skillModifier == null)
            {
                return NotFound();
            }
            return Ok(skillModifier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillModifier(long id, SkillModifier skillModifier)
        {
            if (id != skillModifier.Id)
            {
                return BadRequest();
            }

            await skillModifierService.UpdateSkillModifierAsync(skillModifier);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SkillModifier>> PostSkillModifier(SkillModifier skillModifier)
        {
            await skillModifierService.AddSkillModifierAsync(skillModifier);
            return CreatedAtAction(nameof(GetSkillModifier), new { id = skillModifier.Id }, skillModifier);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillModifier(long id)
        {
            await skillModifierService.DeleteSkillModifierAsync(id);
            return NoContent();
        }
    }
}
