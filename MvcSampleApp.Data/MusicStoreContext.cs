namespace MvcSampleApp.Data
{
    using System.Data.Entity;
    using Core.Models;
    using Interfaces;
    using Mappings;

    public class MusicStoreContext : DbContext, IMusicStoreContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }

        static MusicStoreContext()
        {
            Database.SetInitializer<MusicStoreContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenresMapping());
            modelBuilder.Configurations.Add(new AlbumMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}