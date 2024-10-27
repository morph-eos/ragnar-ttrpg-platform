using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(IClassService classService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return Ok(await classService.GetAllClassesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(long id)
        {
            var @class = await classService.GetClassByIdAsync(id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(long id, Class @class)
        {
            if (id != @class.Id)
            {
                return BadRequest();
            }

            await classService.UpdateClassAsync(@class);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class @class)
        {
            await classService.AddClassAsync(@class);
            return CreatedAtAction(nameof(GetClass), new { id = @class.Id }, @class);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(long id)
        {
            await classService.DeleteClassAsync(id);
            return NoContent();
        }
    }
}
