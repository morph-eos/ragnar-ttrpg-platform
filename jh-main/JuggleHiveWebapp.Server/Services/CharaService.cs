using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class CharaService(PostgresContext context) : ICharaService
    {
        public async Task<Chara?> GetCharaByIdAsync(long id)
        {
            return await context.Charas
                .Include(c => c.User)
                .Include(c => c.Info)
                .Include(c => c.Region)
                .Include(c => c.Race)
                .Include(c => c.LvlUpStat)
                .Include(c => c.CharacterClasses)
                .Include(c => c.CharacterSkills)
                .Include(c => c.CharactersTreePoints)
                .Include(c => c.Inventories)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Chara>> GetAllCharasAsync()
        {
            return await context.Charas
                .Include(c => c.User)
                .Include(c => c.Info)
                .Include(c => c.Region)
                .Include(c => c.Race)
                .Include(c => c.LvlUpStat)
                .Include(c => c.CharacterClasses)
                .Include(c => c.CharacterSkills)
                .Include(c => c.CharactersTreePoints)
                .Include(c => c.Inventories)
                .ToListAsync();
        }

        public async Task AddCharaAsync(Chara chara)
        {
            context.Charas.Add(chara);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCharaAsync(Chara chara)
        {
            context.Charas.Update(chara);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCharaAsync(long id)
        {
            var chara = await context.Charas.FindAsync(id);
            if (chara != null)
            {
                context.Charas.Remove(chara);
                await context.SaveChangesAsync();
            }
        }
    }
}
