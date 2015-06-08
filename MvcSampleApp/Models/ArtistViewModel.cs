using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSampleApp.Models
{
    public class ArtistViewModel
    {
        [Required]
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}