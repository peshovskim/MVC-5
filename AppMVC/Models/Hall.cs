using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public class Hall
    {
        [Display(Name = "Id")]
        [Key]
        public int HallId { get; set; }
        [Display(Name = "Hall Name")]
        public string HallName { get; set; }

        public int NumOFSeats { get; set; }

        public int NumOFAvailableSeats { get; set; }


    }
}