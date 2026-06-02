using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class CharacterClassService(PostgresContext context) : ICharacterClassService
    {
        public async Task<CharacterClass?> GetCharacterClassByIdAsync(long id)
        {
            return await context.CharacterClasses
                .Include(cc => cc.Character)
                .Include(cc => cc.Class)
                .FirstOrDefaultAsync(cc => cc.Id == id);
        }

        public async Task<IEnumerable<CharacterClass>> GetAllCharacterClassesAsync()
        {
            return await context.CharacterClasses
                .Include(cc => cc.Character)
                .Include(cc => cc.Class)
                .ToListAsync();
        }

        public async Task AddCharacterClassAsync(CharacterClass characterClass)
        {
            context.CharacterClasses.Add(characterClass);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCharacterClassAsync(CharacterClass characterClass)
        {
            context.CharacterClasses.Update(characterClass);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCharacterClassAsync(long id)
        {
            var characterClass = await context.CharacterClasses.FindAsync(id);
            if (characterClass != null)
            {
                context.CharacterClasses.Remove(characterClass);
                await context.SaveChangesAsync();
            }
        }
    }
}
