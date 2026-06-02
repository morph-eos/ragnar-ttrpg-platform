/*
 * Race Controller - Character Species Management
 * 
 * Manages character races and species in the TTRPG system.
 * Handles racial traits, stat bonuses, special abilities,
 * regional associations, and race-specific skills.
 * Supports character creation race selection mechanics.
 */

using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController(IRaceService raceService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
        {
            return Ok(await raceService.GetAllRacesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(long id)
        {
            var race = await raceService.GetRaceByIdAsync(id);
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(long id, Race race)
        {
            if (id != race.Id)
            {
                return BadRequest();
            }

            await raceService.UpdateRaceAsync(race);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Race>> PostRace(Race race)
        {
            await raceService.AddRaceAsync(race);
            return CreatedAtAction(nameof(GetRace), new { id = race.Id }, race);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(long id)
        {
            await raceService.DeleteRaceAsync(id);
            return NoContent();
        }
    }
}
