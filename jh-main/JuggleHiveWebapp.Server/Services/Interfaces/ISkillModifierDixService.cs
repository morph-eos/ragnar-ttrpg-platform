using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ISkillModifierDixService
    {
        Task<SkillModifierDix?> GetSkillModifierDixByIdAsync(long id);
        Task<IEnumerable<SkillModifierDix>> GetAllSkillModifierDicesAsync();
        Task AddSkillModifierDixAsync(SkillModifierDix skillModifierDix);
        Task UpdateSkillModifierDixAsync(SkillModifierDix skillModifierDix);
        Task DeleteSkillModifierDixAsync(long id);
    }
}
