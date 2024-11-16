using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class SkillModifierDixService(PostgresContext context) : ISkillModifierDixService
    {
        public async Task<SkillModifierDix?> GetSkillModifierDixByIdAsync(long id)
        {
            return await context.SkillModifierDices
                .Include(dix => dix.SkillModifier)
                .FirstOrDefaultAsync(dix => dix.Id == id);
        }

        public async Task<IEnumerable<SkillModifierDix>> GetAllSkillModifierDicesAsync()
        {
            return await context.SkillModifierDices
                .Include(dix => dix.SkillModifier)
                .ToListAsync();
        }

        public async Task AddSkillModifierDixAsync(SkillModifierDix skillModifierDix)
        {
            context.SkillModifierDices.Add(skillModifierDix);
            await context.SaveChangesAsync();
        }

        public async Task UpdateSkillModifierDixAsync(SkillModifierDix skillModifierDix)
        {
            context.SkillModifierDices.Update(skillModifierDix);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSkillModifierDixAsync(long id)
        {
            var skillModifierDix = await context.SkillModifierDices.FindAsync(id);
            if (skillModifierDix != null)
            {
                context.SkillModifierDices.Remove(skillModifierDix);
                await context.SaveChangesAsync();
            }
        }
    }
}
