using MvcSampleApp.Core.Models;
using MvcSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSampleApp.Extensions
{
    public static class GenreExtensions
    {
        public static Genre ToModel(this GenreViewModel viewModel)
        {
            var genre = new Genre();
            genre.GenreId = viewModel.GenreId;
            genre.Name = viewModel.Name;
            genre.Description = viewModel.Description;

            return genre;
        }
    }
}