using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IAllowedItemService
    {
        Task<AllowedItem?> GetAllowedItemByIdAsync(long id);
        Task<IEnumerable<AllowedItem>> GetAllAllowedItemsAsync();
        Task AddAllowedItemAsync(AllowedItem allowedItem);
        Task UpdateAllowedItemAsync(AllowedItem allowedItem);
        Task DeleteAllowedItemAsync(long id);
    }
}
