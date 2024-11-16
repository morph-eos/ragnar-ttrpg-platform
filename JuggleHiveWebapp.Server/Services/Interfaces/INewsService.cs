using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Services.Interfaces
{
    public interface INewsService
    {
        Task<News?> GetNewsByIdAsync(long id);
        Task<IEnumerable<News>> GetAllNewsAsync();
        Task<IEnumerable<News>> GetImportantNewsAsync();
        Task AddNewsAsync(News news);
        Task UpdateNewsAsync(News news);
        Task DeleteNewsAsync(long id);
    }
}
