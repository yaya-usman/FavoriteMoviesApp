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

        [Required]
        [StringLength(60,MinimumLength =3)]
        public string Title { get; set; }
        
        [Required]
        public Genre Genre { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:0.0#}")]
        public double Rating { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Imdb Link")]
        public string ImdbUrl { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string ImageUrl { get; set; }
    }


}
