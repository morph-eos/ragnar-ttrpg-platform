using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeEntityController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeEntity>>> GetTreeEntities()
        {
            return await context.TreeEntities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreeEntity>> GetTreeEntity(long id)
        {
            var treeEntity = await context.TreeEntities.FindAsync(id);

            if (treeEntity == null)
            {
                return NotFound();
            }

            return treeEntity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreeEntity(long id, TreeEntity treeEntity)
        {
            if (id != treeEntity.Id)
            {
                return BadRequest();
            }

            context.Entry(treeEntity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeEntityExists(id))
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
        public async Task<ActionResult<TreeEntity>> PostTreeEntity(TreeEntity treeEntity)
        {
            context.TreeEntities.Add(treeEntity);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTreeEntity", new { id = treeEntity.Id }, treeEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreeEntity(long id)
        {
            var treeEntity = await context.TreeEntities.FindAsync(id);
            if (treeEntity == null)
            {
                return NotFound();
            }

            context.TreeEntities.Remove(treeEntity);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreeEntityExists(long id)
        {
            return context.TreeEntities.Any(e => e.Id == id);
        }
    }
}
