using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Models;

namespace TunifyPlatform.Data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
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
            //modelBuilder.Entity<PlaylistSongs>().HasKey(pk => new { pk.SongId, pk.PlaylistId });

            // PlaylistSongs and Playlist: Many-to-One
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.playlistSongs)
                .HasForeignKey(ps => ps.PlaylistId)
                .OnDelete(DeleteBehavior.Restrict);

            // PlaylistSongs and Songs: Many-to-One
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.playlistSongs)
                .HasForeignKey(ps => ps.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users and Subscriptions: One-to-Many
            modelBuilder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users and Playlists: One-to-Many
            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Songs and Artists: Many-to-One
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            // Songs and Albums: Many-to-One
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            // Albums and Artists: Many-to-One
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);

            // Seeding Subscription data
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, Subscription_Type = "Basic", Price = 9.99 },
                new Subscription { SubscriptionId = 2, Subscription_Type = "Premium", Price = 19.99 }
            );

            // Seeding Artist data
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Taylor Swift", Bio = "American singer-songwriter, known for narrative songs about her personal life." },
                new Artist { ArtistId = 2, Name = "Ed Sheeran", Bio = "English singer-songwriter, known for his hit singles and acoustic performances." }
            );

            // Seeding Album data
            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, Album_Name = "1989", Release_Date = new DateTime(2014, 10, 27), ArtistId = 1 },
                new Album { AlbumId = 2, Album_Name = "Divide", Release_Date = new DateTime(2017, 3, 3), ArtistId = 2 }
            );

            // Seeding Song data
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Blank Space", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3.5), Genre = "Pop" },
                new Song { SongId = 2, Title = "Shape of You", ArtistId = 2, AlbumId = 2, Duration = TimeSpan.FromMinutes(4), Genre = "Pop" },
                new Song { SongId = 3, Title = "Style", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3.5), Genre = "Pop" },
                new Song { SongId = 4, Title = "Castle on the Hill", ArtistId = 2, AlbumId = 2, Duration = TimeSpan.FromMinutes(4), Genre = "Rock" }
            );

            // Seeding User data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Moayad", Email = "hamadanjo@gmail.com", Join_Date = new DateTime(2024, 1, 15), SubscriptionId = 1 },
                new User { UserId = 2, Username = "Aya", Email = "aya@gmail.com", Join_Date = new DateTime(2024, 2, 10), SubscriptionId = 2 }
            );

            // Seeding Playlist data
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UserId = 1, Playlist_Name = "Morning Motivation", Created_Date = new DateTime(2024, 3, 1) },
                new Playlist { PlaylistId = 2, UserId = 2, Playlist_Name = "Evening Relaxation", Created_Date = new DateTime(2024, 3, 5) },
                new Playlist { PlaylistId = 3, UserId = 1, Playlist_Name = "Workout Hits", Created_Date = new DateTime(2024, 3, 10) },
                new Playlist { PlaylistId = 4, UserId = 2, Playlist_Name = "Road Trip", Created_Date = new DateTime(2024, 3, 15) }
            );

            // Seeding PlaylistSongs data
            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs { PlaylistSongsId = 1, PlaylistId = 1, SongId = 1 },
                new PlaylistSongs { PlaylistSongsId = 2, PlaylistId = 2, SongId = 2 },
                new PlaylistSongs { PlaylistSongsId = 3, PlaylistId = 3, SongId = 3 },
                new PlaylistSongs { PlaylistSongsId = 4, PlaylistId = 4, SongId = 4 }
            );

            // Seed roles and claims
            seedRoles(modelBuilder, "Admin", "create", "update", "delete");
            seedRoles(modelBuilder, "User", "update");

            // Seed the default admin user
            //seedAdminUser(modelBuilder);

        }
        private void seedRoles(ModelBuilder modelBuilder, string roleName, params string[] permission)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            // add claims for the users
            // complete
            var claims = permission.Select(permission => new IdentityRoleClaim<string>
            {
                Id = Guid.NewGuid().GetHashCode(), // Unique identifier
                RoleId = role.Id,
                ClaimType = "permission",
                ClaimValue = permission
            });

            // Seed the role and its claims
            modelBuilder.Entity<IdentityRole>().HasData(role);
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(claims);

        }
        //private void seedAdminUser(ModelBuilder modelBuilder)
        //{
        //    var adminUser = new ApplicationUser
        //    {
        //        Id = "admin_user_id",
        //        UserName = "admin",
        //        NormalizedUserName = "ADMIN",
        //        Email = "admin@example.com",
        //        NormalizedEmail = "ADMIN@EXAMPLE.COM",
        //        EmailConfirmed = true,
        //        SecurityStamp = Guid.NewGuid().ToString("D"),
        //        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        //    };

        //    // Set password for the admin user
        //    var passwordHasher = new PasswordHasher<ApplicationUser>();
        //    adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "AdminPassword123!");

        //    modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

        //    // Assign the admin role to the admin user
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = "admin",
        //        UserId = adminUser.Id
        //    });

        //    // Add any necessary claims to the admin user
        //    modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        //    {
        //        Id = Guid.NewGuid().GetHashCode(),
        //        UserId = adminUser.Id,
        //        ClaimType = "permission",
        //        ClaimValue = "full_access"
        //    });
        //}
    }

}
