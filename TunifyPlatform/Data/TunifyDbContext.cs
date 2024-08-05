using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Models;

namespace TunifyPlatform.Data
{
    public class TunifyDbContext : DbContext
    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options) { }


        public DbSet<User>Users { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Subscription> Subscription { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Moayad", Email = "hamadanjo@gmail.com", Join_Date = new DateTime(2024 - 04 - 08), SubscriptionId = 2 },
                new User { UserId = 2, Username = "Aya", Email = "aya@gmail.com", Join_Date = new DateTime(2024 - 03 - 05), SubscriptionId = 1 },
                new User { UserId = 3, Username = "Jafar", Email = "jafar@gmail.com", Join_Date = new DateTime(2024 - 06 - 06), SubscriptionId = 1 }
                );
            
            //Song
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Blinding Lights", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3), Genre = "Pop" },
                new Song { SongId = 2, Title = "In My Feelings", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(4), Genre = "Hip Hop" }
            );
            
            //Playlist
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UserId = 1, Playlist_Name = "Workout Jams", Created_Date = new DateTime(2024 - 06 - 04) },
                new Playlist { PlaylistId = 2, UserId = 2, Playlist_Name = "Chill Vibes", Created_Date = new DateTime(2024 - 02 - 01) }
            );
        }
    }

}
