using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            return await context.Inventories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(long id)
        {
            var inventory = await context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(long id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }

            context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            context.Inventories.Add(inventory);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(long id)
        {
            var inventory = await context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            context.Inventories.Remove(inventory);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(long id)
        {
            return context.Inventories.Any(e => e.Id == id);
        }
    }
}
