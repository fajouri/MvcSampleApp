using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSampleApp.Models
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        [Required]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}