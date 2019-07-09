using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public class Reservation
    {

        public int ReservationId { get; set; }

        public int TimeTableId { get; set; }
        public int NumOfTickets { get; set; }
        public string ApplicatinUserId { get; set; }
        public virtual TimeTable TimeTable { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}