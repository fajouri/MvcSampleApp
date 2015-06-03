namespace MvcSampleApp.Data.Mappings
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Models;

    public class ArtistsMapping : EntityTypeConfiguration<Artist>
    {
        public ArtistsMapping()
        {
            ToTable("Artists");
            HasKey(t => t.ArtistId);
        }
    }
}