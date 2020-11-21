using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team1_FinalProject.Seeding
{
	public static class SeedTickets
	{
		public static void AddTicket(AppDbContext db)
		{
		    //Create a new list for all of the Tickets
		List<Ticket> AllTickets = new List<Ticket>();
		AllTickets.Add(new Ticket
		{
			SeatNumber = "A1",
            Price = db.Prices.FirstOrDefault(c => c.GenreName == "Adventure"),
		});
		
		AllTickets.Add(new Ticket
		{
			TicketName = "Adventure",
		});
		
		AllTickets.Add(new Ticket
		{
			TicketName = "Animation",
		});
				
		AllTickets.Add(new Ticket
		{
			TicketName = "Comedy",
		});
		
				//create some counters to help debug problems
		Int32 intTicketID = 0;
		String strTicketTitle = "Start";

		//loop through the list to add or update the genre
		try
		{
			foreach (Ticket seedTicket in AllTickets)
			{
				//update the counters
				intTicketID = seedTicket.TicketID;
				strTicketTitle = seedTicket.TicketName;
				//see if the genre is already in the database using the UniqueIdentifier
				Ticket dbTicket = db.Tickets.FirstOrDefault(m => m.TicketID == seedTicket.TicketID);

					//if genre is null, genre is not in database
					if (dbTicket == null)
					{
						//Add the genre to the database
						db.Tickets.Add(seedTicket);
						db.SaveChanges();
					}
					else //the genre is in the database - reset all fields except ID and Unique Identifier
					{
						dbTicket.TicketName = seedTicket.TicketName;
						db.SaveChanges();
					}
				}
			}
			catch (Exception ex) //throw error if there is a problem in the database
			{
				StringBuilder msg = new StringBuilder();
				msg.Append("There was a problem adding the genre with the title: ");
				msg.Append(strTicketTitle);
				msg.Append(" (TicketID: ");
				msg.Append(intTicketID);
				msg.Append(")");
				throw new Exception(msg.ToString(), ex);
			}
		}
	}
}
