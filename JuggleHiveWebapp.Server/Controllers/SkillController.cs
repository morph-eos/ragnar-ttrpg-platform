using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController(ISkillService skillService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            return Ok(await skillService.GetAllSkillsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(long id)
        {
            var skill = await skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpGet("family/{skillFamilyId}")]
        public async Task<IActionResult> GetSkillsByFamilyId(long skillFamilyId)
        {
            var skills = await skillService.GetSkillsByFamilyIdAsync(skillFamilyId);
            return Ok(skills);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(long id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            await skillService.UpdateSkillAsync(skill);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            await skillService.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkill), new { id = skill.Id }, skill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(long id)
        {
            await skillService.DeleteSkillAsync(id);
            return NoContent();
        }
    }
}
