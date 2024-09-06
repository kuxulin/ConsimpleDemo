using ConsimpleDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleDemo.Extensions;

public static class ProgramExtension
{

    public static void AddDatabaseAndEntities(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>(options =>
           options.UseSqlServer(connectionString));
    }
}
