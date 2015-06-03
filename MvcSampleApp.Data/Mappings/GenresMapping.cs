namespace MvcSampleApp.Data.Mappings
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Models;

    public class GenresMapping : EntityTypeConfiguration<Genre>
    {
        public GenresMapping()
        {
            ToTable("Genres");
            HasKey(t => t.GenreId);
        }
    }
}