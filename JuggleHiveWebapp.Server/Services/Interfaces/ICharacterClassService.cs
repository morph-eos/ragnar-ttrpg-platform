using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ICharacterClassService
    {
        Task<CharacterClass?> GetCharacterClassByIdAsync(long id);
        Task<IEnumerable<CharacterClass>> GetAllCharacterClassesAsync();
        Task AddCharacterClassAsync(CharacterClass characterClass);
        Task UpdateCharacterClassAsync(CharacterClass characterClass);
        Task DeleteCharacterClassAsync(long id);
    }
}
