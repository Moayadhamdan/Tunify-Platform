using System.Collections.Generic;
using System.Threading.Tasks;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task<Song> GetSongByIdAsync(int id);
        Task AddSongAsync(SongDto songdto);
        Task UpdateSongAsync(Song song);
        Task DeleteSongAsync(int id);
    }
}
