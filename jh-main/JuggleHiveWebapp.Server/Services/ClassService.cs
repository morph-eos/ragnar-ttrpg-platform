using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class ClassService(PostgresContext context) : IClassService
    {
        public async Task<Class?> GetClassByIdAsync(long id)
        {
            return await context.Classes
                .Include(c => c.AllowedItems)
                .Include(c => c.CharacterClasses)
                .Include(c => c.Stats)
                .Include(c => c.Tree)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await context.Classes
                .Include(c => c.AllowedItems)
                .Include(c => c.CharacterClasses)
                .Include(c => c.Stats)
                .Include(c => c.Tree)
                .ToListAsync();
        }

        public async Task AddClassAsync(Class classEntity)
        {
            context.Classes.Add(classEntity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateClassAsync(Class classEntity)
        {
            context.Classes.Update(classEntity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(long id)
        {
            var classEntity = await context.Classes.FindAsync(id);
            if (classEntity != null)
            {
                context.Classes.Remove(classEntity);
                await context.SaveChangesAsync();
            }
        }
    }
}
