using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ISkillModifierService
    {
        Task<SkillModifier?> GetSkillModifierByIdAsync(long id);
        Task<IEnumerable<SkillModifier>> GetAllSkillModifiersAsync();
        Task AddSkillModifierAsync(SkillModifier skillModifier);
        Task UpdateSkillModifierAsync(SkillModifier skillModifier);
        Task DeleteSkillModifierAsync(long id);
    }
}
