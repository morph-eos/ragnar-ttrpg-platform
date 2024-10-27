using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Services
{
    public class UserService(PostgresContext context) : IUserService
    {
    }
}
