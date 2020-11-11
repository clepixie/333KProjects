using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    //define enum
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
        public String Room { get; set; }
        //enum

        [Display(Name = "Is This a Special Event?")]
        public Boolean SpecialEvent { get; set; }
        public Movie Movie { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
