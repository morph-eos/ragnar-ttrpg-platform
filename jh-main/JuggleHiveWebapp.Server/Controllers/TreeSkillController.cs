using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeSkillController(ITreeSkillService treeSkillService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeSkill>>> GetTreeSkills()
        {
            return Ok(await treeSkillService.GetAllTreeSkillsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreeSkill>> GetTreeSkill(long id)
        {
            var treeSkill = await treeSkillService.GetTreeSkillByIdAsync(id);
            if (treeSkill == null)
            {
                return NotFound();
            }
            return Ok(treeSkill);
        }

        [HttpGet("tree/{treeId}")]
        public async Task<IActionResult> GetTreeSkillsByTreeId(long treeId)
        {
            var treeSkills = await treeSkillService.GetTreeSkillsByTreeIdAsync(treeId);
            return Ok(treeSkills);
        }

        [HttpGet("skillfamily/{skillFamilyId}")]
        public async Task<IActionResult> GetTreeSkillsBySkillFamilyId(long skillFamilyId)
        {
            var treeSkills = await treeSkillService.GetTreeSkillsBySkillFamilyIdAsync(skillFamilyId);
            return Ok(treeSkills);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreeSkill(long id, TreeSkill treeSkill)
        {
            if (id != treeSkill.Id)
            {
                return BadRequest();
            }

            await treeSkillService.UpdateTreeSkillAsync(treeSkill);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TreeSkill>> PostTreeSkill(TreeSkill treeSkill)
        {
            await treeSkillService.AddTreeSkillAsync(treeSkill);
            return CreatedAtAction(nameof(GetTreeSkill), new { id = treeSkill.Id }, treeSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreeSkill(long id)
        {
            await treeSkillService.DeleteTreeSkillAsync(id);
            return NoContent();
        }
    }
}
