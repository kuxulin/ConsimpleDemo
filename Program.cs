
using ConsimpleDemo.Extensions;

namespace ConsimpleDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDatabaseAndEntities(builder.Configuration.GetConnectionString("DatabaseConnection"));

        builder.Services.AddRepositories();
        builder.Services.AddServices();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer(); 
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
