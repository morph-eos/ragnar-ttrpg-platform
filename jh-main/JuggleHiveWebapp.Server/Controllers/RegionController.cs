using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController(IRegionService regionService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return Ok(await regionService.GetAllRegionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(long id)
        {
            var region = await regionService.GetRegionByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(long id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            await regionService.UpdateRegionAsync(region);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            await regionService.AddRegionAsync(region);
            return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, region);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(long id)
        {
            await regionService.DeleteRegionAsync(id);
            return NoContent();
        }
    }
}
