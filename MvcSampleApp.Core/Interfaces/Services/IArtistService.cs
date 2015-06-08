namespace MvcSampleApp.Core.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IArtistService : IDisposable
    {
        IEnumerable<Artist> GetAll();
        Artist GetById(int artistId);
        void Save(Artist artist);
        void Delete(int artistId);
        void Delete(Artist artist);
    }
}