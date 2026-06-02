using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IBaseStatService
    {
        Task<BaseStat?> GetBaseStatByIdAsync(long id);
        Task<IEnumerable<BaseStat>> GetAllBaseStatsAsync();
        Task AddBaseStatAsync(BaseStat baseStat);
        Task UpdateBaseStatAsync(BaseStat baseStat);
        Task DeleteBaseStatAsync(long id);
    }
}
