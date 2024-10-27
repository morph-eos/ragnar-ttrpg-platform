using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class InventoryService(PostgresContext context) : IInventoryService
    {
        public async Task<Inventory?> GetInventoryByIdAsync(long id)
        {
            return await context.Inventories
                .Include(i => i.Character)
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await context.Inventories
                .Include(i => i.Character)
                .Include(i => i.Items)
                .ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            context.Inventories.Add(inventory);
            await context.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            context.Inventories.Update(inventory);
            await context.SaveChangesAsync();
        }

        public async Task DeleteInventoryAsync(long id)
        {
            var inventory = await context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                context.Inventories.Remove(inventory);
                await context.SaveChangesAsync();
            }
        }
    }
}
