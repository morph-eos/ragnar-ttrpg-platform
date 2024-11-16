using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IRegionService
    {
        Task<Region?> GetRegionByIdAsync(long id);
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task AddRegionAsync(Region region);
        Task UpdateRegionAsync(Region region);
        Task DeleteRegionAsync(long id);
    }
}
