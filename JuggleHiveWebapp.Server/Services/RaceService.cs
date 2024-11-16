using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class RaceService(PostgresContext context) : IRaceService
    {
        public async Task<Race?> GetRaceByIdAsync(long id)
        {
            return await context.Races
                .Include(r => r.Stat)
                .Include(r => r.RaceSkills)
                .Include(r => r.Regions)
                .Include(r => r.Charas)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Race>> GetAllRacesAsync()
        {
            return await context.Races
                .Include(r => r.Stat)
                .Include(r => r.RaceSkills)
                .Include(r => r.Regions)
                .ToListAsync();
        }

        public async Task AddRaceAsync(Race race)
        {
            context.Races.Add(race);
            await context.SaveChangesAsync();
        }

        public async Task UpdateRaceAsync(Race race)
        {
            context.Races.Update(race);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRaceAsync(long id)
        {
            var race = await context.Races.FindAsync(id);
            if (race != null)
            {
                context.Races.Remove(race);
                await context.SaveChangesAsync();
            }
        }
    }
}
