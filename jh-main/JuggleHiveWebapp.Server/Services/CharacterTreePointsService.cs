using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class CharacterTreePointsService(PostgresContext context) : ICharactersTreePointService
    {
        public async Task<CharactersTreePoint?> GetCharactersTreePointByIdAsync(long id)
        {
            return await context.CharactersTreePoints
                .Include(ctp => ctp.Character)
                .Include(ctp => ctp.Tree)
                .FirstOrDefaultAsync(ctp => ctp.Id == id);
        }

        public async Task<IEnumerable<CharactersTreePoint>> GetAllCharactersTreePointsAsync()
        {
            return await context.CharactersTreePoints
                .Include(ctp => ctp.Character)
                .Include(ctp => ctp.Tree)
                .ToListAsync();
        }

        public async Task AddCharactersTreePointAsync(CharactersTreePoint charactersTreePoint)
        {
            context.CharactersTreePoints.Add(charactersTreePoint);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCharactersTreePointAsync(CharactersTreePoint charactersTreePoint)
        {
            context.CharactersTreePoints.Update(charactersTreePoint);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCharactersTreePointAsync(long id)
        {
            var charactersTreePoint = await context.CharactersTreePoints.FindAsync(id);
            if (charactersTreePoint != null)
            {
                context.CharactersTreePoints.Remove(charactersTreePoint);
                await context.SaveChangesAsync();
            }
        }
    }
}
