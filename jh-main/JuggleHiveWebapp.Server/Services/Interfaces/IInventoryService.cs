using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory?> GetInventoryByIdAsync(long id);
        Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        Task AddInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(long id);
    }
}
