using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
	public class Ticket
	{
		public Int32 TicketID { get; set; }

		[Display(Name = "Seat Number:")]
		public String SeatNumber { get; set; }

		public Decimal Price { get; set; }
		
		public Booleon SeatClaim { get; set; }

		public Order Order { get; set; }

		public Showing Showing { get; set; }


	}
    
}
