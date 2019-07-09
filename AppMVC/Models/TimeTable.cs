using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public class TimeTable
    {
        [Key]
        public int TimeId { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString="{MM/DD/YYYY hh:mm}")]
   
        public DateTime Time { get; set; }
        public Hall Hall { get; set; }
        public Movie Movie { get; set; }
    }
}