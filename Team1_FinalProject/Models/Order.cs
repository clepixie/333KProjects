using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class Order
    {
	
	    [Display(Name = "OrderID")]
	    public Int32 OrderID {get; set;}

	    [Display(Name = "Is this a gift order?")]	
	    public Boolean GiftOrder {get; set;}
	
	    [Display(Name = "Do you want to use Popcorn Points?")]
	    public Boolean PopcornPoints {get; set;}
	
	    public DateTime Date { get; set; }

	    public List<OrderDetail> OrderDetails { get; set; }

	    public Order()
        {
			if (OrderDetails == null)
			{
				OrderDetails = new List<OrderDetail>();
            }
        }

        
    }
}
