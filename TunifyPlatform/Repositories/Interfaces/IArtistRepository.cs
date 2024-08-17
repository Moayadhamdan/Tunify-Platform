using System.Collections.Generic;
using System.Threading.Tasks;
using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int id);
        Task AddArtistAsync(Artist artist);
        Task UpdateArtistAsync(Artist artist);
        Task DeleteArtistAsync(int id);
        Task<Song> AddSongToArtist(int artistId, int songId);
        Task<List<Song>> GetAllSongsFromArtist(int artistId);
    }
}
