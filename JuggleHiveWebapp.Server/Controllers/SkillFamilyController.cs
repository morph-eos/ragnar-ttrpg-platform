using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillFamilyController(ISkillFamilyService skillFamilyService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillFamily>>> GetSkillFamilies()
        {
            return Ok(await skillFamilyService.GetAllSkillFamiliesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillFamily>> GetSkillFamily(long id)
        {
            var skillFamily = await skillFamilyService.GetSkillFamilyByIdAsync(id);
            if (skillFamily == null)
            {
                return NotFound();
            }
            return Ok(skillFamily);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillFamily(long id, SkillFamily skillFamily)
        {
            if (id != skillFamily.Id)
            {
                return BadRequest();
            }

            await skillFamilyService.UpdateSkillFamilyAsync(skillFamily);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SkillFamily>> PostSkillFamily(SkillFamily skillFamily)
        {
            await skillFamilyService.AddSkillFamilyAsync(skillFamily);
            return CreatedAtAction(nameof(GetSkillFamily), new { id = skillFamily.Id }, skillFamily);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillFamily(long id)
        {
            await skillFamilyService.DeleteSkillFamilyAsync(id);
            return NoContent();
        }
    }
}
