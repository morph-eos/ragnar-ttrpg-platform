using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeEntityController(ITreeEntityService treeEntityService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeEntity>>> GetTreeEntities()
        {
            return Ok(await treeEntityService.GetAllTreeEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreeEntity>> GetTreeEntity(long id)
        {
            var treeEntity = await treeEntityService.GetTreeEntityByIdAsync(id);
            if (treeEntity == null)
            {
                return NotFound();
            }
            return Ok(treeEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreeEntity(long id, TreeEntity treeEntity)
        {
            if (id != treeEntity.Id)
            {
                return BadRequest();
            }

            await treeEntityService.UpdateTreeEntityAsync(treeEntity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TreeEntity>> PostTreeEntity(TreeEntity treeEntity)
        {
            await treeEntityService.AddTreeEntityAsync(treeEntity);
            return CreatedAtAction(nameof(GetTreeEntity), new { id = treeEntity.Id }, treeEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreeEntity(long id)
        {
            await treeEntityService.DeleteTreeEntityAsync(id);
            return NoContent();
        }
    }
}
