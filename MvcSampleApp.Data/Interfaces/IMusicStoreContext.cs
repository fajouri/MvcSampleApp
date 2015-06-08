namespace MvcSampleApp.Data.Interfaces
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Core.Models;

    public interface IMusicStoreContext
    {
        DbSet<Genre> Genres { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbEntityEntry Entry(object entity);

        int SaveChanges();
        void Dispose();
    }
}