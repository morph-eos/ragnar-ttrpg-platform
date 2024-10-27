using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseStatController(IBaseStatService baseStatService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseStat>>> GetBaseStats()
        {
            return Ok(await baseStatService.GetAllBaseStatsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseStat>> GetBaseStat(long id)
        {
            var baseStat = await baseStatService.GetBaseStatByIdAsync(id);
            if (baseStat == null)
            {
                return NotFound();
            }
            return Ok(baseStat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseStat(long id, BaseStat baseStat)
        {
            if (id != baseStat.Id)
            {
                return BadRequest();
            }

            await baseStatService.UpdateBaseStatAsync(baseStat);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BaseStat>> PostBaseStat(BaseStat baseStat)
        {
            await baseStatService.AddBaseStatAsync(baseStat);
            return CreatedAtAction(nameof(GetBaseStat), new { id = baseStat.Id }, baseStat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseStat(long id)
        {
            await baseStatService.DeleteBaseStatAsync(id);
            return NoContent();
        }
    }
}
