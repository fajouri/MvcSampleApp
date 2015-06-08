namespace MvcSampleApp.Data.Mappings
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Models;

    public class AlbumMapping : EntityTypeConfiguration<Album>
    {
        public AlbumMapping()
        {
            Property(t => t.Title).HasMaxLength(160);
            Property(t => t.AlbumUrl).HasMaxLength(1024);
       }
    }
}