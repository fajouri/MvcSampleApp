namespace MvcSampleApp.Core.Models
{
    using System.Collections.Generic;

    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Album> Albums { get; set; } 
    }
}