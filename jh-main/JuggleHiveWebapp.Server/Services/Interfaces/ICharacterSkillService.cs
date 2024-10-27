using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ICharacterSkillService
    {
        Task<CharacterSkill?> GetCharacterSkillByIdAsync(long id);
        Task<IEnumerable<CharacterSkill>> GetAllCharacterSkillsAsync();
        Task AddCharacterSkillAsync(CharacterSkill characterSkill);
        Task UpdateCharacterSkillAsync(CharacterSkill characterSkill);
        Task DeleteCharacterSkillAsync(long id);
    }
}
