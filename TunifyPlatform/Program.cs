using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Get the connection string settings
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

           builder.Services.AddDbContext<TunifyDbContext>(op => op.UseSqlServer(ConnectionStringVar));

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
