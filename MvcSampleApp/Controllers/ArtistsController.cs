using MvcSampleApp.Core.Models;
using MvcSampleApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleApp.Controllers
{
    public class ArtistsController : Controller
    {
        // GET: Artists
        public ActionResult Index()
        {
            using (var context = new MusicStoreContext())
            {
                var artists = context.Artists.Distinct().ToList();                
                return View(artists);
            }            
        }

        public ActionResult New()
        {
            Artist artist = new Artist();
            return View(artist);
        }

        [HttpPost]
        public ActionResult New(Artist artist)
        {
            using (var context = new MusicStoreContext())
            {
                var artists = context.Artists.Add(artist);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(int artistId)
        {
            using (var context = new MusicStoreContext())
            {
                var artist = context.Artists.FirstOrDefault(a => a.ArtistId.Equals(artistId));
                return View(artist);
            }
        }

        [HttpPost]
        public ActionResult Update(Artist artist)
        {
            using (var context = new MusicStoreContext())
            {
                var currentArtist = context.Artists.FirstOrDefault(a => a.ArtistId.Equals(artist.ArtistId));
                currentArtist.Name = artist.Name;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int artistId)
        {
            using (var context = new MusicStoreContext())
            {
                var artist = context.Artists.FirstOrDefault(a => a.ArtistId.Equals(artistId));
                return View(artist);
            }
        }

        [HttpPost]
        public ActionResult DeleteArtist(int artistId)
        {
            using (var context = new MusicStoreContext())
            {
                var artist = context.Artists.FirstOrDefault(a => a.ArtistId.Equals(artistId));
                context.Artists.Remove(artist);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}