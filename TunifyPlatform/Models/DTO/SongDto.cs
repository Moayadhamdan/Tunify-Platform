namespace TunifyPlatform.Models.DTO
{
    public class SongDto
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }
    }
}
