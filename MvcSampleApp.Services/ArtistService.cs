namespace MvcSampleApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Core.Interfaces.Services;
    using Core.Models;
    using Data;
    using Data.Interfaces;

    public class ArtistService : IArtistService
    {
        private readonly IMusicStoreContext context;

        static ArtistService()
        {
            var dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public ArtistService() : this(new MusicStoreContext())
        {
        }

        public ArtistService(IMusicStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artist> GetAll()
        {
            return context.Artists.OrderBy(g => g.Name).ToList();
        }

        public Artist GetById(int artistId)
        {
            return context.Artists.FirstOrDefault(g => g.ArtistId.Equals(artistId));
        }

        public void Save(Artist artist)
        {
            ValidateArtist(artist);

            if (artist.ArtistId == 0)
            {
                context.Artists.Add(artist);
            }
            else
            {
                context.Artists.Attach(artist);
                context.Entry(artist).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void Delete(int artistId)
        {
            Delete(new Artist{ArtistId = artistId});    
        }

        public void Delete(Artist artist)
        {
            if (artist.ArtistId == 0)
            {
                throw new ArgumentException("Id cannot be empty");
            }

            context.Artists.Attach(artist);
            context.Entry(artist).State = EntityState.Deleted;
            context.SaveChanges();
        }

        private static void ValidateArtist(Artist artist)
        {
            if (string.IsNullOrWhiteSpace(artist.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}