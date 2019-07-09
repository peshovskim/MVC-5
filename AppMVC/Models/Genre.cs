using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public class Genre
    {

        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}