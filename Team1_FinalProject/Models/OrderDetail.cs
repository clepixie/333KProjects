using System;
namespace Team1_FinalProject.Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {
	
	public Int32 OrderDetailID {get; set;}
	
	[Display(Name = "Seat Number:")]
	public String SeatNumber {get; set;}

	public Order Order {get; set;}

	public Showing Showing {get; set;}

        }
    }
}
