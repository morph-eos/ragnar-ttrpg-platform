using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class CharacterSkillService(PostgresContext context) : ICharacterSkillService
    {
        public async Task<CharacterSkill?> GetCharacterSkillByIdAsync(long id)
        {
            return await context.CharacterSkills
                .Include(cs => cs.Character)
                .Include(cs => cs.UnlockedSkill)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task<IEnumerable<CharacterSkill>> GetAllCharacterSkillsAsync()
        {
            return await context.CharacterSkills
                .Include(cs => cs.Character)
                .Include(cs => cs.UnlockedSkill)
                .ToListAsync();
        }

        public async Task AddCharacterSkillAsync(CharacterSkill characterSkill)
        {
            context.CharacterSkills.Add(characterSkill);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCharacterSkillAsync(CharacterSkill characterSkill)
        {
            context.CharacterSkills.Update(characterSkill);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCharacterSkillAsync(long id)
        {
            var characterSkill = await context.CharacterSkills.FindAsync(id);
            if (characterSkill != null)
            {
                context.CharacterSkills.Remove(characterSkill);
                await context.SaveChangesAsync();
            }
        }
    }
}
