using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ISkillService
    {
        Task<Skill?> GetSkillByIdAsync(long id);
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<IEnumerable<Skill>> GetSkillsByFamilyIdAsync(long skillFamilyId);
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(long id);
    }
}
