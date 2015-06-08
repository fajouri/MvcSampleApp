namespace MvcSampleApp.Core.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumUrl { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
