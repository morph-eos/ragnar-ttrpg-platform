using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillModifierDixController(ISkillModifierDixService skillModifierDixService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillModifierDix>>> GetSkillModifierDices()
        {
            return Ok(await skillModifierDixService.GetAllSkillModifierDicesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillModifierDix>> GetSkillModifierDix(long id)
        {
            var skillModifierDix = await skillModifierDixService.GetSkillModifierDixByIdAsync(id);
            if (skillModifierDix == null)
            {
                return NotFound();
            }
            return Ok(skillModifierDix);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillModifierDix(long id, SkillModifierDix skillModifierDix)
        {
            if (id != skillModifierDix.Id)
            {
                return BadRequest();
            }

            await skillModifierDixService.UpdateSkillModifierDixAsync(skillModifierDix);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SkillModifierDix>> PostSkillModifierDix(SkillModifierDix skillModifierDix)
        {
            await skillModifierDixService.AddSkillModifierDixAsync(skillModifierDix);
            return CreatedAtAction(nameof(GetSkillModifierDix), new { id = skillModifierDix.Id }, skillModifierDix);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillModifierDix(long id)
        {
            await skillModifierDixService.DeleteSkillModifierDixAsync(id);
            return NoContent();
        }
    }
}
