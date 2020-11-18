using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class Order
    {
		public const Decimal TAX_RATE = .0825m;

	    [Display(Name = "OrderID:")]
	    public Int32 OrderID {get; set;}

	    [Display(Name = "Is this a gift order?")]	
	    public Boolean GiftOrder {get; set;}
	
	    [Display(Name = "Do you want to use Popcorn Points?")]
	    public Boolean PopcornPoints {get; set;}

		[Display(Name = "Date:")]
	    public DateTime Date { get; set; }

		[Display(Name = "Order Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
		public Decimal OrderSubtotal
        {
            get { return Tickets.Sum(t => t.Price); }
        }

		[Display(Name = "Tax (8.25%):")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Tax
        {
            get { return OrderSubtotal * TAX_RATE; }
        }
        [Display(Name = "Order Total:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal
        {
            get { return OrderSubtotal + Tax; }
        }

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
