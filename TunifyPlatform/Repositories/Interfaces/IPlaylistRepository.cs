using System.Collections.Generic;
using System.Threading.Tasks;
using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();
        Task<Playlist> GetPlaylistByIdAsync(int id);
        Task AddPlaylistAsync(Playlist playlist);
        Task UpdatePlaylistAsync(Playlist playlist);
        Task DeletePlaylistAsync(int id);
        Task <bool> AddSongToPlaylist(int playlistId, int songId);
        Task<List<Song>> GetAllSongsFromPlayList(int playlistId);
    }
}
