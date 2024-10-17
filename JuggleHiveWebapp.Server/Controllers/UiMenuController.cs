using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UiMenuController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UiMenu>>> GetUiMenus()
        {
            return await context.UiMenus.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UiMenu>> GetUiMenu(long id)
        {
            var uiMenu = await context.UiMenus.FindAsync(id);

            if (uiMenu == null)
            {
                return NotFound();
            }

            return uiMenu;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUiMenu(long id, UiMenu uiMenu)
        {
            if (id != uiMenu.Id)
            {
                return BadRequest();
            }

            context.Entry(uiMenu).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UiMenuExists(id))
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
        public async Task<ActionResult<UiMenu>> PostUiMenu(UiMenu uiMenu)
        {
            context.UiMenus.Add(uiMenu);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UiMenuExists(uiMenu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUiMenu", new { id = uiMenu.Id }, uiMenu);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUiMenu(long id)
        {
            var uiMenu = await context.UiMenus.FindAsync(id);
            if (uiMenu == null)
            {
                return NotFound();
            }

            context.UiMenus.Remove(uiMenu);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool UiMenuExists(long id)
        {
            return context.UiMenus.Any(e => e.Id == id);
        }
    }
}
