using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleApp.Controllers
{
    using Core.Models;
    using Data;

    public class GenresController : Controller
    {
        //
        // GET: /Genres/
        public ActionResult Index()
        {
            using (var context = new MusicStoreContext())
            {
                var genres = context.Genres.ToList();
                return View(genres);
            }
        }

        public ActionResult New()
        {
            var genre = new Genre();

            return View(genre);
        }

        [HttpPost]
        public ActionResult New(Genre genre)
        {
            using (var context = new MusicStoreContext())
            {
                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Update(int genreId)
        {
            using (var context = new MusicStoreContext())
            {
                var genre = context.Genres.FirstOrDefault(g => g.GenreId.Equals(genreId));

                return View(genre);
            }
        }

        [HttpPost]
        public ActionResult Update(Genre genre)
        {
            using (var context = new MusicStoreContext())
            {
                var currentGenre = context.Genres.FirstOrDefault(g => g.GenreId.Equals(genre.GenreId));
                currentGenre.Name = genre.Name;
                currentGenre.Description = genre.Description;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int genreId)
        {
            using (var context = new MusicStoreContext())
            {
                var genre = context.Genres.FirstOrDefault(g => g.GenreId.Equals(genreId));

                return View(genre);
            }
        }

        [HttpPost]
        public ActionResult DeleteGenre(int genreId)
        {
            using ( var context = new MusicStoreContext())
            {
                var genre = context.Genres.FirstOrDefault(g => g.GenreId.Equals(genreId));
                context.Genres.Remove(genre);

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
	}
}