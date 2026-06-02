using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class RegionService(PostgresContext context) : IRegionService
    {
        public async Task<Region?> GetRegionByIdAsync(long id)
        {
            return await context.Regions
                .Include(r => r.Charas)
                .Include(r => r.Races)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await context.Regions
                .Include(r => r.Charas)
                .Include(r => r.Races)
                .ToListAsync();
        }

        public async Task AddRegionAsync(Region region)
        {
            context.Regions.Add(region);
            await context.SaveChangesAsync();
        }

        public async Task UpdateRegionAsync(Region region)
        {
            context.Regions.Update(region);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRegionAsync(long id)
        {
            var region = await context.Regions.FindAsync(id);
            if (region != null)
            {
                context.Regions.Remove(region);
                await context.SaveChangesAsync();
            }
        }
    }
}
