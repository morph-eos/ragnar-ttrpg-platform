using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Services
{
    public class NewsService(PostgresContext context) : INewsService
    {
    }
}
