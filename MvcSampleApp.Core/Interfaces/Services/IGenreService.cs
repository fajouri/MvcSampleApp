namespace MvcSampleApp.Core.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IGenreService : IDisposable
    {
        IEnumerable<Genre> GetAll();
        Genre GetById(int genereId);
        void Save(Genre genre);
        void Delete(int genreId);
        void Delete(Genre genre);
    }
}