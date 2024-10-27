using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class BaseStatService(PostgresContext context) : IBaseStatService
    {
        public async Task<BaseStat?> GetBaseStatByIdAsync(long id)
        {
            return await context.BaseStats
                .Include(bs => bs.Charas)
                .Include(bs => bs.Classes)
                .Include(bs => bs.Races)
                .FirstOrDefaultAsync(bs => bs.Id == id);
        }

        public async Task<IEnumerable<BaseStat>> GetAllBaseStatsAsync()
        {
            return await context.BaseStats
                .Include(bs => bs.Charas)
                .Include(bs => bs.Classes)
                .Include(bs => bs.Races)
                .ToListAsync();
        }

        public async Task AddBaseStatAsync(BaseStat baseStat)
        {
            context.BaseStats.Add(baseStat);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBaseStatAsync(BaseStat baseStat)
        {
            context.BaseStats.Update(baseStat);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBaseStatAsync(long id)
        {
            var baseStat = await context.BaseStats.FindAsync(id);
            if (baseStat != null)
            {
                context.BaseStats.Remove(baseStat);
                await context.SaveChangesAsync();
            }
        }
    }
}
