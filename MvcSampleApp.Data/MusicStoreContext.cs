namespace MvcSampleApp.Data
{
    using System.Data.Entity;
    using Core.Models;
    using Mappings;

    public class MusicStoreContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenresMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}