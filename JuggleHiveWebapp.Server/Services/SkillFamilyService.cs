using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class SkillFamilyService(PostgresContext context) : ISkillFamilyService
    {
        public async Task<SkillFamily?> GetSkillFamilyByIdAsync(long id)
        {
            return await context.SkillFamilies
                .Include(sf => sf.Skills)
                .Include(sf => sf.TreeSkillParentSkillFamilies)
                .Include(sf => sf.TreeSkillSkillFamilies)
                .FirstOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<IEnumerable<SkillFamily>> GetAllSkillFamiliesAsync()
        {
            return await context.SkillFamilies
                .Include(sf => sf.Skills)
                .Include(sf => sf.TreeSkillParentSkillFamilies)
                .Include(sf => sf.TreeSkillSkillFamilies)
                .ToListAsync();
        }

        public async Task AddSkillFamilyAsync(SkillFamily skillFamily)
        {
            context.SkillFamilies.Add(skillFamily);
            await context.SaveChangesAsync();
        }

        public async Task UpdateSkillFamilyAsync(SkillFamily skillFamily)
        {
            context.SkillFamilies.Update(skillFamily);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSkillFamilyAsync(long id)
        {
            var skillFamily = await context.SkillFamilies.FindAsync(id);
            if (skillFamily != null)
            {
                context.SkillFamilies.Remove(skillFamily);
                await context.SaveChangesAsync();
            }
        }
    }
}
