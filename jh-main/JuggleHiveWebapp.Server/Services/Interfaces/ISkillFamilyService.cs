using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ISkillFamilyService
    {
        Task<SkillFamily?> GetSkillFamilyByIdAsync(long id);
        Task<IEnumerable<SkillFamily>> GetAllSkillFamiliesAsync();
        Task AddSkillFamilyAsync(SkillFamily skillFamily);
        Task UpdateSkillFamilyAsync(SkillFamily skillFamily);
        Task DeleteSkillFamilyAsync(long id);
    }
}
