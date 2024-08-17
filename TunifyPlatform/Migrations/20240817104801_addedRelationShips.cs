using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DeleteData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "SongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "SongId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistId",
                table: "Song",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Users_UserId",
                table: "Playlist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Users_UserId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Song_AlbumId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_ArtistId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistId",
                table: "Album");

            migrationBuilder.InsertData(
                table: "Playlist",
                columns: new[] { "PlaylistId", "Created_Date", "Playlist_Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Workout Jams", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021), "Chill Vibes", 2 }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "AlbumId", "ArtistId", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 0, 0), "Pop", "Blinding Lights" },
                    { 2, 1, 1, new TimeSpan(0, 0, 4, 0, 0), "Hip Hop", "In My Feelings" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Join_Date", "SubscriptionId", "Username" },
                values: new object[,]
                {
                    { 1, "hamadanjo@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2012), 2, "Moayad" },
                    { 2, "aya@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016), 1, "Aya" },
                    { 3, "jafar@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2012), 1, "Jafar" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
