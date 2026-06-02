using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class RaceSkillService(PostgresContext context) : IRaceSkillService
    {
        public async Task<RaceSkill?> GetRaceSkillByIdAsync(long id)
        {
            return await context.RaceSkills
                .Include(rs => rs.Race)
                .Include(rs => rs.SkillTree)
                .FirstOrDefaultAsync(rs => rs.Id == id);
        }

        public async Task<IEnumerable<RaceSkill>> GetAllRaceSkillsAsync()
        {
            return await context.RaceSkills
                .Include(rs => rs.Race)
                .Include(rs => rs.SkillTree)
                .ToListAsync();
        }

        public async Task<IEnumerable<RaceSkill>> GetSkillsByRaceIdAsync(long raceId)
        {
            return await context.RaceSkills
                .Where(rs => rs.RaceId == raceId)
                .Include(rs => rs.SkillTree)
                .ToListAsync();
        }

        public async Task AddRaceSkillAsync(RaceSkill raceSkill)
        {
            context.RaceSkills.Add(raceSkill);
            await context.SaveChangesAsync();
        }

        public async Task UpdateRaceSkillAsync(RaceSkill raceSkill)
        {
            context.RaceSkills.Update(raceSkill);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRaceSkillAsync(long id)
        {
            var raceSkill = await context.RaceSkills.FindAsync(id);
            if (raceSkill != null)
            {
                context.RaceSkills.Remove(raceSkill);
                await context.SaveChangesAsync();
            }
        }
    }
}
