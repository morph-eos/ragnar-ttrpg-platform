using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ICharactersTreePointService
    {
        Task<CharactersTreePoint?> GetCharactersTreePointByIdAsync(long id);
        Task<IEnumerable<CharactersTreePoint>> GetAllCharactersTreePointsAsync();
        Task AddCharactersTreePointAsync(CharactersTreePoint charactersTreePoint);
        Task UpdateCharactersTreePointAsync(CharactersTreePoint charactersTreePoint);
        Task DeleteCharactersTreePointAsync(long id);
    }
}
