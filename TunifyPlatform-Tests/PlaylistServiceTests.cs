using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform_Tests
{
    public class PlaylistRepositoryTests
    {
        [Fact]
        public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
        {
            // Arrange
            var playlistId = 1;
            var songs = new List<Song>
        {
            new Song { SongId = 3, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3), Genre = "Pop" },
            new Song { SongId = 4, Title = "Song 2", ArtistId = 2, AlbumId = 2, Duration = TimeSpan.FromMinutes(4), Genre = "Rock" }
        };

            var mockRepository = new Mock<IPlaylistRepository>();
            mockRepository.Setup(repo => repo.GetAllSongsFromPlayList(playlistId))
                          .ReturnsAsync(songs);

            // Act
            var result = await mockRepository.Object.GetAllSongsFromPlayList(playlistId);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Title == "Song 1");
            Assert.Contains(result, s => s.Title == "Song 2");
        }
    }

}
