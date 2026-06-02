using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceSkillController(IRaceSkillService raceSkillService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceSkill>>> GetRaceSkills()
        {
            return Ok(await raceSkillService.GetAllRaceSkillsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceSkill>> GetRaceSkill(long id)
        {
            var raceSkill = await raceSkillService.GetRaceSkillByIdAsync(id);
            if (raceSkill == null)
            {
                return NotFound();
            }
            return Ok(raceSkill);
        }

        [HttpGet("race/{raceId}")]
        public async Task<IActionResult> GetSkillsByRaceId(long raceId)
        {
            var raceSkills = await raceSkillService.GetSkillsByRaceIdAsync(raceId);
            return Ok(raceSkills);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceSkill(long id, RaceSkill raceSkill)
        {
            if (id != raceSkill.Id)
            {
                return BadRequest();
            }

            await raceSkillService.UpdateRaceSkillAsync(raceSkill);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RaceSkill>> PostRaceSkill(RaceSkill raceSkill)
        {
            await raceSkillService.AddRaceSkillAsync(raceSkill);
            return CreatedAtAction(nameof(GetRaceSkill), new { id = raceSkill.Id }, raceSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceSkill(long id)
        {
            await raceSkillService.DeleteRaceSkillAsync(id);
            return NoContent();
        }
    }
}
