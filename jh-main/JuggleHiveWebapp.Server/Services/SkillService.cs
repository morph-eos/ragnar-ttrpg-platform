using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class SkillService(PostgresContext context) : ISkillService
    {
        public async Task<Skill?> GetSkillByIdAsync(long id)
        {
            return await context.Skills
                .Include(s => s.SkillFamily)
                .Include(s => s.CharacterSkills)
                .Include(s => s.Items)
                .Include(s => s.SkillModifiers)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await context.Skills
                .Include(s => s.SkillFamily)
                .Include(s => s.CharacterSkills)
                .Include(s => s.Items)
                .Include(s => s.SkillModifiers)
                .ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetSkillsByFamilyIdAsync(long skillFamilyId)
        {
            return await context.Skills
                .Where(s => s.SkillFamilyId == skillFamilyId)
                .Include(s => s.SkillFamily)
                .Include(s => s.SkillModifiers)
                .ToListAsync();
        }

        public async Task AddSkillAsync(Skill skill)
        {
            context.Skills.Add(skill);
            await context.SaveChangesAsync();
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            context.Skills.Update(skill);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(long id)
        {
            var skill = await context.Skills.FindAsync(id);
            if (skill != null)
            {
                context.Skills.Remove(skill);
                await context.SaveChangesAsync();
            }
        }
    }
}
