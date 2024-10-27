using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class ItemService(PostgresContext context) : IItemService
    {
        public async Task<Item?> GetItemByIdAsync(long id)
        {
            return await context.Items
                .Include(i => i.MainSkill)
                .Include(i => i.Inventories)
                .Include(i => i.Skills)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await context.Items
                .Include(i => i.MainSkill)
                .Include(i => i.Inventories)
                .Include(i => i.Skills)
                .ToListAsync();
        }

        public async Task AddItemAsync(Item item)
        {
            context.Items.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(long id)
        {
            var item = await context.Items.FindAsync(id);
            if (item != null)
            {
                context.Items.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
