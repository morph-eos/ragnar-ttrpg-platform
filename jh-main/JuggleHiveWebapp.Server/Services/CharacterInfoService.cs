using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class CharacterInfoService(PostgresContext context) : ICharacterInfoService
    {
        public async Task<CharacterInfo?> GetCharacterInfoByIdAsync(long id)
        {
            return await context.CharacterInfos
                .Include(ci => ci.Charas)
                .FirstOrDefaultAsync(ci => ci.Id == id);
        }

        public async Task<IEnumerable<CharacterInfo>> GetAllCharacterInfosAsync()
        {
            return await context.CharacterInfos
                .Include(ci => ci.Charas)
                .ToListAsync();
        }

        public async Task AddCharacterInfoAsync(CharacterInfo characterInfo)
        {
            context.CharacterInfos.Add(characterInfo);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCharacterInfoAsync(CharacterInfo characterInfo)
        {
            context.CharacterInfos.Update(characterInfo);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCharacterInfoAsync(long id)
        {
            var characterInfo = await context.CharacterInfos.FindAsync(id);
            if (characterInfo != null)
            {
                context.CharacterInfos.Remove(characterInfo);
                await context.SaveChangesAsync();
            }
        }
    }
}
