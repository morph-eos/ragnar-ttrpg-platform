using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class AllowedItemService(PostgresContext context) : IAllowedItemService
    {
        public async Task<AllowedItem?> GetAllowedItemByIdAsync(long id)
        {
            return await context.AllowedItems
                .Include(ai => ai.Class)
                .FirstOrDefaultAsync(ai => ai.Id == id);
        }

        public async Task<IEnumerable<AllowedItem>> GetAllAllowedItemsAsync()
        {
            return await context.AllowedItems
                .Include(ai => ai.Class)
                .ToListAsync();
        }

        public async Task AddAllowedItemAsync(AllowedItem allowedItem)
        {
            context.AllowedItems.Add(allowedItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAllowedItemAsync(AllowedItem allowedItem)
        {
            context.AllowedItems.Update(allowedItem);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAllowedItemAsync(long id)
        {
            var allowedItem = await context.AllowedItems.FindAsync(id);
            if (allowedItem != null)
            {
                context.AllowedItems.Remove(allowedItem);
                await context.SaveChangesAsync();
            }
        }
    }
}
