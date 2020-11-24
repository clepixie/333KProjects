using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Team1_FinalProject.Models
{
        
    // in the controller, we will need to add spaces like below:
    // switch (employee):
    // {
    //   case 1: return "Theater 1";
    //   // same for the rest
    // }
    public class Showing
    {
        public Int32 ShowingID { get; set; }

        [Display(Name = "Starts At")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "Ends At")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Theater Room")]
        public int Room { get; set; }

        [Display(Name = "Is This a Special Event?")]
        public Boolean SpecialEvent { get; set; }

        public Movie Movie { get; set; }

        public List<Ticket> Tickets { get; set; }
        [Display(Name = "Price")]
        public Price Price { get; set; }

        [Display(Name = "Tickets Available")]
        public int TicketCount
        {
            get
            {
                return (20 - Tickets.Count());
            }
        }

        public Showing()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }
        
    }
}
