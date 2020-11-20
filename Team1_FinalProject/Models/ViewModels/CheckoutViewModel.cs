using System;
using System.Collections.Generic;

namespace Team1_FinalProject.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Showing> Showings { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Order> Orders { get; set; }
    }
    
}
