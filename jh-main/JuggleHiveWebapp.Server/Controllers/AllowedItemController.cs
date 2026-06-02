using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowedItemController(IAllowedItemService allowedItemService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowedItem>>> GetAllowedItems()
        {
            return Ok(await allowedItemService.GetAllAllowedItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AllowedItem>> GetAllowedItem(long id)
        {
            var allowedItem = await allowedItemService.GetAllowedItemByIdAsync(id);

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

            await allowedItemService.UpdateAllowedItemAsync(allowedItem);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AllowedItem>> PostAllowedItem(AllowedItem allowedItem)
        {
            await allowedItemService.AddAllowedItemAsync(allowedItem);
            return CreatedAtAction(nameof(GetAllowedItem), new { id = allowedItem.Id }, allowedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowedItem(long id)
        {
            await allowedItemService.DeleteAllowedItemAsync(id);
            return NoContent();
        }
    }
}
