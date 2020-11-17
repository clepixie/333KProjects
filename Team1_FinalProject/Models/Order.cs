using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class Order
    {
	
	    [Display(Name = "OrderID:")]
	    public Int32 OrderID {get; set;}

	    [Display(Name = "Is this a gift order?")]	
	    public Boolean GiftOrder {get; set;}
	
	    [Display(Name = "Do you want to use Popcorn Points?")]
	    public Boolean PopcornPoints {get; set;}

		[Display(Name = "Date:")]
	    public DateTime Date { get; set; }

		public Decimal Total { get; set; }
		// the total price of all tickets purchased on this order

		public AppUser Customer { get; set; }

	    public List<Ticket> Tickets { get; set; }

	    public Order()
        {
			if (Tickets == null)
			{
				Tickets = new List<Ticket>();
            }
        }

        
    }
}
