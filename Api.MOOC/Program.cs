using Api.MOOC.IServices;
using Api.MOOC.Models;
using Api.MOOC.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.MOOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MoocDbContext>(options => 
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(8, 0, 33)))
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            CheckDatabaseConnection(app);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void CheckDatabaseConnection(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MoocDbContext>();
                try
                {
                    if (dbContext.Database.CanConnect())
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed：{ex.Message}");
                }
            }
        }
    }
}
