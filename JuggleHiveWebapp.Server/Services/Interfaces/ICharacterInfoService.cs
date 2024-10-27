using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ICharacterInfoService
    {
        Task<CharacterInfo?> GetCharacterInfoByIdAsync(long id);
        Task<IEnumerable<CharacterInfo>> GetAllCharacterInfosAsync();
        Task AddCharacterInfoAsync(CharacterInfo characterInfo);
        Task UpdateCharacterInfoAsync(CharacterInfo characterInfo);
        Task DeleteCharacterInfoAsync(long id);
    }
}
