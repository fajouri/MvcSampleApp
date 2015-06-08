using MvcSampleApp.Core.Models;
using MvcSampleApp.Data;
using MvcSampleApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcSampleApp.Controllers
{
    using System;
    using Core.Interfaces.Services;
    using Services;

    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController()
            : this(new ArtistService())
        {

        }

        public ArtistsController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public ActionResult Index()
        {
            var artists = artistService.GetAll();               
            return View(artists);
        }

        public ActionResult New()
        {
            var artist = new ArtistViewModel();
            return View(artist);
        }

        [HttpPost]
        public ActionResult New(ArtistViewModel viewModel)
        {
            var artist = Helpers.ModelHelpers.ToModel<Artist, ArtistViewModel>(viewModel);

            try
            {
                artistService.Save(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(viewModel);
            }
        }

        public ActionResult Update(int artistId)
        {
            var artist = artistService.GetById(artistId);
            var viewModel = Helpers.ModelHelpers.ToModel<ArtistViewModel, Artist>(artist);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(ArtistViewModel viewModel)
        {
            var artist = Helpers.ModelHelpers.ToModel<Artist, ArtistViewModel>(viewModel);

            try
            {
                artistService.Save(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(viewModel);
            }
        }

        public ActionResult Delete(int artistId)
        {
            var artist = artistService.GetById(artistId);

            var viewModel = Helpers.ModelHelpers.ToModel<ArtistViewModel, Artist>(artist);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteArtist(ArtistViewModel model)
        {
            try
            {
                artistService.Delete(model.ArtistId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View("Delete", model);
            }
        }
    }
}