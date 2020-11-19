﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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

        [Display(Name = "Start Date Time")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Date Time")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Theater Room")]
        public int Room { get; set; }

        [Display(Name = "Is This a Special Event?")]
        public Boolean SpecialEvent { get; set; }

        public Movie Movie { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Price Price { get; set; }

        public int TicketCount
        {
            get
            {
                int count = 0;

                foreach (Ticket ticket in Tickets)
                {
                    count += 1;
                }

                return count;
            }
        }

    }
}
