using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ITreeSkillService
    {
        Task<TreeSkill?> GetTreeSkillByIdAsync(long id);
        Task<IEnumerable<TreeSkill>> GetTreeSkillsByTreeIdAsync(long treeId);
        Task<IEnumerable<TreeSkill>> GetTreeSkillsBySkillFamilyIdAsync(long skillFamilyId);
        Task<IEnumerable<TreeSkill>> GetAllTreeSkillsAsync();
        Task AddTreeSkillAsync(TreeSkill treeSkill);
        Task UpdateTreeSkillAsync(TreeSkill treeSkill);
        Task DeleteTreeSkillAsync(long id);
    }
}
