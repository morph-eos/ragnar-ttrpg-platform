using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowedItemController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowedItem>>> GetAllowedItems()
        {
            return await context.AllowedItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AllowedItem>> GetAllowedItem(long id)
        {
            var allowedItem = await context.AllowedItems.FindAsync(id);

            if (allowedItem == null)
            {
                return NotFound();
            }

            return allowedItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowedItem(long id, AllowedItem allowedItem)
        {
            if (id != allowedItem.Id)
            {
                return BadRequest();
            }

            context.Entry(allowedItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowedItemExists(id))
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
        public async Task<ActionResult<AllowedItem>> PostAllowedItem(AllowedItem allowedItem)
        {
            context.AllowedItems.Add(allowedItem);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAllowedItem", new { id = allowedItem.Id }, allowedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowedItem(long id)
        {
            var allowedItem = await context.AllowedItems.FindAsync(id);
            if (allowedItem == null)
            {
                return NotFound();
            }

            context.AllowedItems.Remove(allowedItem);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllowedItemExists(long id)
        {
            return context.AllowedItems.Any(e => e.Id == id);
        }
    }
}
