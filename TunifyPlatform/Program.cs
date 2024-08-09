using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;
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


            // Add services to the container.
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<ISongRepository, SongRepository>();
            builder.Services.AddScoped<IArtistRepository, ArtistRepository>();

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
