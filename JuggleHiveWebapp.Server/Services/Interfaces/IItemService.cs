using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IItemService
    {
        Task<Item?> GetItemByIdAsync(long id);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(long id);
    }
}
