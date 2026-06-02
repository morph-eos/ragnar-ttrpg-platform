using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface ITreeEntityService
    {
        Task<TreeEntity?> GetTreeEntityByIdAsync(long id);
        Task<IEnumerable<TreeEntity>> GetAllTreeEntitiesAsync();
        Task AddTreeEntityAsync(TreeEntity treeEntity);
        Task UpdateTreeEntityAsync(TreeEntity treeEntity);
        Task DeleteTreeEntityAsync(long id);
    }
}
