using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class TreeSkillService(PostgresContext context) : ITreeSkillService
    {
        public async Task<TreeSkill?> GetTreeSkillByIdAsync(long id)
        {
            return await context.TreeSkills
                .Include(ts => ts.Tree)
                .Include(ts => ts.SkillFamily)
                .Include(ts => ts.ParentSkillFamily)
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<IEnumerable<TreeSkill>> GetTreeSkillsByTreeIdAsync(long treeId)
        {
            return await context.TreeSkills
                .Where(ts => ts.TreeId == treeId)
                .Include(ts => ts.Tree)
                .Include(ts => ts.SkillFamily)
                .Include(ts => ts.ParentSkillFamily)
                .ToListAsync();
        }

        public async Task AddTreeSkillAsync(TreeSkill treeSkill)
        {
            context.TreeSkills.Add(treeSkill);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTreeSkillAsync(TreeSkill treeSkill)
        {
            context.TreeSkills.Update(treeSkill);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTreeSkillAsync(long id)
        {
            var treeSkill = await context.TreeSkills.FindAsync(id);
            if (treeSkill != null)
            {
                context.TreeSkills.Remove(treeSkill);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TreeSkill>> GetTreeSkillsBySkillFamilyIdAsync(long skillFamilyId)
        {
            return await context.TreeSkills
                .Where(ts => ts.SkillFamilyId == skillFamilyId)
                .Include(ts => ts.Tree)
                .Include(ts => ts.SkillFamily)
                .Include(ts => ts.ParentSkillFamily)
                .ToListAsync();
        }

        public async Task<IEnumerable<TreeSkill>> GetAllTreeSkillsAsync()
        {
            return await context.TreeSkills
                .Include(ts => ts.Tree)
                .Include(ts => ts.SkillFamily)
                .Include(ts => ts.ParentSkillFamily)
                .ToListAsync();
                
        }
    }
}
