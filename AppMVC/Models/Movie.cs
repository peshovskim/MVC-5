using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        //public int GenreId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int PriceForTcket { get; set; }

        public string ImgUrl { get; set; }

        public string YoutubeURL { get; set; }

        public string Description { get; set; }
        [Range(0.00, 10.00)]
        public double Rating { get; set; }
        [Range(0, 300)]
        public int Duration { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual List<TimeTable> TimeTables { get; set; }
        public Movie()
        {
            TimeTables = new List<TimeTable>();
          //  Genres = new List<Genre>();
        }
    }
}