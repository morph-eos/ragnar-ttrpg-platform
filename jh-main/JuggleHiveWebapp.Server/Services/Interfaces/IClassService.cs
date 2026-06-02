using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface IClassService
    {
        Task<Class?> GetClassByIdAsync(long id);
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task AddClassAsync(Class classEntity);
        Task UpdateClassAsync(Class classEntity);
        Task DeleteClassAsync(long id);
    }
}
