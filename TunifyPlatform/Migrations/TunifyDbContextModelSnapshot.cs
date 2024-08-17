﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TunifyPlatform.Data;

#nullable disable

namespace TunifyPlatform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    partial class TunifyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TunifyPlatform.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("Album_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Release_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            Album_Name = "1989",
                            ArtistId = 1,
                            Release_Date = new DateTime(2014, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AlbumId = 2,
                            Album_Name = "Divide",
                            ArtistId = 2,
                            Release_Date = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            Bio = "American singer-songwriter, known for narrative songs about her personal life.",
                            Name = "Taylor Swift"
                        },
                        new
                        {
                            ArtistId = 2,
                            Bio = "English singer-songwriter, known for his hit singles and acoustic performances.",
                            Name = "Ed Sheeran"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Playlist_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId");

                    b.HasIndex("UserId");

                    b.ToTable("Playlist");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            Created_Date = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Playlist_Name = "Morning Motivation",
                            UserId = 1
                        },
                        new
                        {
                            PlaylistId = 2,
                            Created_Date = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Playlist_Name = "Evening Relaxation",
                            UserId = 2
                        },
                        new
                        {
                            PlaylistId = 3,
                            Created_Date = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Playlist_Name = "Workout Hits",
                            UserId = 1
                        },
                        new
                        {
                            PlaylistId = 4,
                            Created_Date = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Playlist_Name = "Road Trip",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("PlaylistSongsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistSongsId"));

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongsId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");

                    b.HasData(
                        new
                        {
                            PlaylistSongsId = 1,
                            PlaylistId = 1,
                            SongId = 1
                        },
                        new
                        {
                            PlaylistSongsId = 2,
                            PlaylistId = 2,
                            SongId = 2
                        },
                        new
                        {
                            PlaylistSongsId = 3,
                            PlaylistId = 3,
                            SongId = 3
                        },
                        new
                        {
                            PlaylistSongsId = 4,
                            PlaylistId = 4,
                            SongId = 4
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Song");

                    b.HasData(
                        new
                        {
                            SongId = 1,
                            AlbumId = 1,
                            ArtistId = 1,
                            Duration = new TimeSpan(0, 0, 3, 30, 0),
                            Genre = "Pop",
                            Title = "Blank Space"
                        },
                        new
                        {
                            SongId = 2,
                            AlbumId = 2,
                            ArtistId = 2,
                            Duration = new TimeSpan(0, 0, 4, 0, 0),
                            Genre = "Pop",
                            Title = "Shape of You"
                        },
                        new
                        {
                            SongId = 3,
                            AlbumId = 1,
                            ArtistId = 1,
                            Duration = new TimeSpan(0, 0, 3, 30, 0),
                            Genre = "Pop",
                            Title = "Style"
                        },
                        new
                        {
                            SongId = 4,
                            AlbumId = 2,
                            ArtistId = 2,
                            Duration = new TimeSpan(0, 0, 4, 0, 0),
                            Genre = "Rock",
                            Title = "Castle on the Hill"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Subscription_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscription");

                    b.HasData(
                        new
                        {
                            SubscriptionId = 1,
                            Price = 9.9900000000000002,
                            Subscription_Type = "Basic"
                        },
                        new
                        {
                            SubscriptionId = 2,
                            Price = 19.989999999999998,
                            Subscription_Type = "Premium"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Join_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "hamadanjo@gmail.com",
                            Join_Date = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionId = 1,
                            Username = "Moayad"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "aya@gmail.com",
                            Join_Date = new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionId = 2,
                            Username = "Aya"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Album", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Playlist", b =>
                {
                    b.HasOne("TunifyPlatform.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TunifyPlatform.Models.PlaylistSongs", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Playlist", "Playlist")
                        .WithMany("playlistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TunifyPlatform.Models.Song", "Song")
                        .WithMany("playlistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Song", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TunifyPlatform.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunifyPlatform.Models.User", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Subscription", "Subscription")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Playlist", b =>
                {
                    b.Navigation("playlistSongs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Song", b =>
                {
                    b.Navigation("playlistSongs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Subscription", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TunifyPlatform.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
