using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IRaceService
    {
        Task<Race?> GetRaceByIdAsync(long id);
        Task<IEnumerable<Race>> GetAllRacesAsync();
        Task AddRaceAsync(Race race);
        Task UpdateRaceAsync(Race race);
        Task DeleteRaceAsync(long id);
    }
}
