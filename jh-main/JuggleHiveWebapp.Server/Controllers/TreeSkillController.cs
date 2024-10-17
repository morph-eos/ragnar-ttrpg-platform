using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeSkillController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeSkill>>> GetTreeSkills()
        {
            return await context.TreeSkills.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreeSkill>> GetTreeSkill(long id)
        {
            var treeSkill = await context.TreeSkills.FindAsync(id);

            if (treeSkill == null)
            {
                return NotFound();
            }

            return treeSkill;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreeSkill(long id, TreeSkill treeSkill)
        {
            if (id != treeSkill.Id)
            {
                return BadRequest();
            }

            context.Entry(treeSkill).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeSkillExists(id))
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
        public async Task<ActionResult<TreeSkill>> PostTreeSkill(TreeSkill treeSkill)
        {
            context.TreeSkills.Add(treeSkill);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTreeSkill", new { id = treeSkill.Id }, treeSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreeSkill(long id)
        {
            var treeSkill = await context.TreeSkills.FindAsync(id);
            if (treeSkill == null)
            {
                return NotFound();
            }

            context.TreeSkills.Remove(treeSkill);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreeSkillExists(long id)
        {
            return context.TreeSkills.Any(e => e.Id == id);
        }
    }
}
