using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TvShowsApp.Models
{
    public class TvShowModel
    {
       
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public double Rating { get; set; }

        public string ImdbUrl { get; set; }
    }


}
