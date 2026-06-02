using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersTreePointController(ICharactersTreePointService charactersTreePointService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharactersTreePoint>>> GetCharactersTreePoints()
        {
            return Ok(await charactersTreePointService.GetAllCharactersTreePointsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharactersTreePoint?>> GetCharactersTreePoint(long id)
        {
            var charactersTreePoint = await charactersTreePointService.GetCharactersTreePointByIdAsync(id);

            if (charactersTreePoint == null)
            {
                return NotFound();
            }

            return charactersTreePoint;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharactersTreePoint(long id, CharactersTreePoint charactersTreePoint)
        {
            if (id != charactersTreePoint.Id)
            {
                return BadRequest();
            }

            await charactersTreePointService.UpdateCharactersTreePointAsync(charactersTreePoint);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CharactersTreePoint>> PostCharactersTreePoint(CharactersTreePoint charactersTreePoint)
        {
            await charactersTreePointService.AddCharactersTreePointAsync(charactersTreePoint);
            return CreatedAtAction(nameof(GetCharactersTreePoint), new { id = charactersTreePoint.Id }, charactersTreePoint);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharactersTreePoint(long id)
        {
            await charactersTreePointService.DeleteCharactersTreePointAsync(id);
            return NoContent();
        }
    }
}
