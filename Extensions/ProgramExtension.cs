using ConsimpleDemo.Data;
using ConsimpleDemo.Models;
using ConsimpleDemo.Repositories;
using ConsimpleDemo.Repositories.Interfaces;
using ConsimpleDemo.Services;
using ConsimpleDemo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleDemo.Extensions;

public static class ProgramExtension
{

    public static void AddDatabaseAndEntities(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>(options =>
           options.UseSqlServer(connectionString));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
