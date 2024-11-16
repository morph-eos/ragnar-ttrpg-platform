using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IRaceSkillService
    {
        Task<RaceSkill?> GetRaceSkillByIdAsync(long id);
        Task<IEnumerable<RaceSkill>> GetAllRaceSkillsAsync();
        Task<IEnumerable<RaceSkill>> GetSkillsByRaceIdAsync(long raceId);
        Task AddRaceSkillAsync(RaceSkill raceSkill);
        Task UpdateRaceSkillAsync(RaceSkill raceSkill);
        Task DeleteRaceSkillAsync(long id);
    }
}
