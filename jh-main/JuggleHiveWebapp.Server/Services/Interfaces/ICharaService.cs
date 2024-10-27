using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ICharaService
    {
        Task<Chara?> GetCharaByIdAsync(long id);
        Task<IEnumerable<Chara>> GetAllCharasAsync();
        Task AddCharaAsync(Chara chara);
        Task UpdateCharaAsync(Chara chara);
        Task DeleteCharaAsync(long id);
    }
}
