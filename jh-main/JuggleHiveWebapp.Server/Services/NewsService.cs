using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Services
{
    public class NewsService(PostgresContext context) : INewsService
    {

        public async Task<News?> GetNewsByIdAsync(long id)
        {
            return await context.News.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await context.News
                .OrderByDescending(n => n.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<News>> GetImportantNewsAsync()
        {
            return await context.News
                .Where(n => n.FlImportant == 1)
                .OrderByDescending(n => n.Date)
                .ToListAsync();
        }

        public async Task AddNewsAsync(News news)
        {
            context.News.Add(news);
            await context.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(News news)
        {
            context.News.Update(news);
            await context.SaveChangesAsync();
        }

        public async Task DeleteNewsAsync(long id)
        {
            var news = await context.News.FindAsync(id);
            if (news != null)
            {
                context.News.Remove(news);
                await context.SaveChangesAsync();
            }
        }
    }
}
