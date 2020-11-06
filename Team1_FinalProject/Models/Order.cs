using System;
namespace Team1_FinalProject.Models
{
    public class Order
    {
        public Order()
        {
	
	[Display(Name = "OrderID")]
	public Int32 OrderID {get; set;}

	[Display(Name = "Is this a gift order?]	
	public Boolean GiftOrder {get; set;}
	
	[Display(Name = Do you want to use Popcorn Points?"]
	public Boolean PopcornPoints {get; set;}
	
	public DateTime {get; set;}

	public List<OrderDetails> OrderDetails {get; set;}

	public Order()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetails>();
            }
        }

        }
    }
}
