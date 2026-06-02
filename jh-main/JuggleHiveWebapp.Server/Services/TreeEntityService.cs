using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class TreeEntityService(PostgresContext context) : ITreeEntityService
    {
        public async Task<TreeEntity?> GetTreeEntityByIdAsync(long id)
        {
            return await context.TreeEntities
                .Include(te => te.CharactersTreePoints)
                .Include(te => te.Classes)
                .Include(te => te.RaceSkills)
                .Include(te => te.TreeSkills)
                .FirstOrDefaultAsync(te => te.Id == id);
        }

        public async Task<IEnumerable<TreeEntity>> GetAllTreeEntitiesAsync()
        {
            return await context.TreeEntities
                .Include(te => te.CharactersTreePoints)
                .Include(te => te.Classes)
                .Include(te => te.RaceSkills)
                .Include(te => te.TreeSkills)
                .ToListAsync();
        }

        public async Task AddTreeEntityAsync(TreeEntity treeEntity)
        {
            context.TreeEntities.Add(treeEntity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTreeEntityAsync(TreeEntity treeEntity)
        {
            context.TreeEntities.Update(treeEntity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTreeEntityAsync(long id)
        {
            var treeEntity = await context.TreeEntities.FindAsync(id);
            if (treeEntity != null)
            {
                context.TreeEntities.Remove(treeEntity);
                await context.SaveChangesAsync();
            }
        }
    }
}
