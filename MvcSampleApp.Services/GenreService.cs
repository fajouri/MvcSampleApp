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

    public class GenreService : IGenreService
    {
        private readonly IMusicStoreContext context;

        public GenreService() : this(new MusicStoreContext())
        {
        }

        public GenreService(IMusicStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genres.OrderBy(g => g.Name).ToList();
        }

        public Genre GetById(int genereId)
        {
            return context.Genres.FirstOrDefault(g => g.GenreId.Equals(genereId));
        }

        public void Save(Genre genre)
        {
            ValidateGenre(genre);

            if (genre.GenreId == 0)
            {
                context.Genres.Add(genre);
            }
            else
            {
                context.Genres.Attach(genre);
                context.Entry(genre).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void Delete(int genreId)
        {
            Delete(new Genre{GenreId = genreId});    
        }

        public void Delete(Genre genre)
        {
            if (genre.GenreId == 0)
            {
                throw new ArgumentException("Id cannot be empty");
            }

            context.Genres.Attach(genre);
            context.Entry(genre).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private static void ValidateGenre(Genre genre)
        {
            if (string.IsNullOrWhiteSpace(genre.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
}