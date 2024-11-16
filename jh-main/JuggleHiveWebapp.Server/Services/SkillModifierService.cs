using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class SkillModifierService(PostgresContext context) : ISkillModifierService
    {
        public async Task<SkillModifier?> GetSkillModifierByIdAsync(long id)
        {
            return await context.SkillModifiers
                .Include(sm => sm.Skill)
                .Include(sm => sm.SkillModifierDices)
                .FirstOrDefaultAsync(sm => sm.Id == id);
        }

        public async Task<IEnumerable<SkillModifier>> GetAllSkillModifiersAsync()
        {
            return await context.SkillModifiers
                .Include(sm => sm.Skill)
                .Include(sm => sm.SkillModifierDices)
                .ToListAsync();
        }

        public async Task AddSkillModifierAsync(SkillModifier skillModifier)
        {
            context.SkillModifiers.Add(skillModifier);
            await context.SaveChangesAsync();
        }

        public async Task UpdateSkillModifierAsync(SkillModifier skillModifier)
        {
            context.SkillModifiers.Update(skillModifier);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSkillModifierAsync(long id)
        {
            var skillModifier = await context.SkillModifiers.FindAsync(id);
            if (skillModifier != null)
            {
                context.SkillModifiers.Remove(skillModifier);
                await context.SaveChangesAsync();
            }
        }
    }
}
