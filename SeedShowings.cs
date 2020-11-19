using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team1_FinalProject.Seeding
{
	public static class SeedShowings
	{
		public static void SeedShowings(AppDbContext db)
		{
		    //Create a new list for all of the Showings
		List<Showing> AllShowings = new List<Showing>();
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,9,5),
			EndDateTime = new DateTime(2020,11,15,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,9,5),
			EndDateTime = new DateTime(2020,11,15,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,11,30),
			EndDateTime = new DateTime(2020,11,15,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,14,0),
			EndDateTime = new DateTime(2020,11,15,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,15,55),
			EndDateTime = new DateTime(2020,11,15,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,18,40),
			EndDateTime = new DateTime(2020,11,15,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,21,37),
			EndDateTime = new DateTime(2020,11,15,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,9,5),
			EndDateTime = new DateTime(2020,11,16,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,11,30),
			EndDateTime = new DateTime(2020,11,16,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,14,0),
			EndDateTime = new DateTime(2020,11,16,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,15,55),
			EndDateTime = new DateTime(2020,11,16,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,18,40),
			EndDateTime = new DateTime(2020,11,16,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,21,37),
			EndDateTime = new DateTime(2020,11,16,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,9,5),
			EndDateTime = new DateTime(2020,11,17,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,11,30),
			EndDateTime = new DateTime(2020,11,17,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,14,0),
			EndDateTime = new DateTime(2020,11,17,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,15,55),
			EndDateTime = new DateTime(2020,11,17,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,18,40),
			EndDateTime = new DateTime(2020,11,17,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,21,37),
			EndDateTime = new DateTime(2020,11,17,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,9,5),
			EndDateTime = new DateTime(2020,11,18,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,11,30),
			EndDateTime = new DateTime(2020,11,18,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,14,0),
			EndDateTime = new DateTime(2020,11,18,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,15,55),
			EndDateTime = new DateTime(2020,11,18,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,18,40),
			EndDateTime = new DateTime(2020,11,18,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,21,37),
			EndDateTime = new DateTime(2020,11,18,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,9,5),
			EndDateTime = new DateTime(2020,11,19,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,11,30),
			EndDateTime = new DateTime(2020,11,19,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,14,0),
			EndDateTime = new DateTime(2020,11,19,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,15,55),
			EndDateTime = new DateTime(2020,11,19,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,18,40),
			EndDateTime = new DateTime(2020,11,19,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,21,37),
			EndDateTime = new DateTime(2020,11,19,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,9,5),
			EndDateTime = new DateTime(2020,11,20,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,11,30),
			EndDateTime = new DateTime(2020,11,20,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,14,0),
			EndDateTime = new DateTime(2020,11,20,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,15,55),
			EndDateTime = new DateTime(2020,11,20,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,18,40),
			EndDateTime = new DateTime(2020,11,20,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,21,37),
			EndDateTime = new DateTime(2020,11,20,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,9,5),
			EndDateTime = new DateTime(2020,11,21,10,52),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Footloose"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,11,30),
			EndDateTime = new DateTime(2020,11,21,13,24),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "WarGames"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,14,0),
			EndDateTime = new DateTime(2020,11,21,15,29),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Office Space"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,15,55),
			EndDateTime = new DateTime(2020,11,21,17,55),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Diamonds are Forever"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,18,40),
			EndDateTime = new DateTime(2020,11,21,21,12),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "West Side Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,21,37),
			EndDateTime = new DateTime(2020,11,21,23,59),
			Room = 1,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Forrest Gump"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,9,0),
			EndDateTime = new DateTime(2020,11,15,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,10,50),
			EndDateTime = new DateTime(2020,11,15,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,13,0),
			EndDateTime = new DateTime(2020,11,15,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,15,20),
			EndDateTime = new DateTime(2020,11,15,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,17,25),
			EndDateTime = new DateTime(2020,11,15,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,19,30),
			EndDateTime = new DateTime(2020,11,15,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,15,22,40),
			EndDateTime = new DateTime(2020,11,15,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,9,0),
			EndDateTime = new DateTime(2020,11,16,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,10,50),
			EndDateTime = new DateTime(2020,11,16,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,13,0),
			EndDateTime = new DateTime(2020,11,16,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,15,20),
			EndDateTime = new DateTime(2020,11,16,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,17,25),
			EndDateTime = new DateTime(2020,11,16,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,19,30),
			EndDateTime = new DateTime(2020,11,16,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,16,22,40),
			EndDateTime = new DateTime(2020,11,16,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,9,0),
			EndDateTime = new DateTime(2020,11,17,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,10,50),
			EndDateTime = new DateTime(2020,11,17,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,13,0),
			EndDateTime = new DateTime(2020,11,17,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,15,20),
			EndDateTime = new DateTime(2020,11,17,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,17,25),
			EndDateTime = new DateTime(2020,11,17,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,19,30),
			EndDateTime = new DateTime(2020,11,17,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,17,22,40),
			EndDateTime = new DateTime(2020,11,17,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,9,0),
			EndDateTime = new DateTime(2020,11,18,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,10,50),
			EndDateTime = new DateTime(2020,11,18,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,13,0),
			EndDateTime = new DateTime(2020,11,18,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,15,20),
			EndDateTime = new DateTime(2020,11,18,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,17,25),
			EndDateTime = new DateTime(2020,11,18,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,19,30),
			EndDateTime = new DateTime(2020,11,18,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,18,22,40),
			EndDateTime = new DateTime(2020,11,18,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,9,0),
			EndDateTime = new DateTime(2020,11,19,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,10,50),
			EndDateTime = new DateTime(2020,11,19,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,13,0),
			EndDateTime = new DateTime(2020,11,19,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,15,20),
			EndDateTime = new DateTime(2020,11,19,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,17,25),
			EndDateTime = new DateTime(2020,11,19,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,19,30),
			EndDateTime = new DateTime(2020,11,19,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,19,22,40),
			EndDateTime = new DateTime(2020,11,19,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,9,0),
			EndDateTime = new DateTime(2020,11,20,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,10,50),
			EndDateTime = new DateTime(2020,11,20,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,13,0),
			EndDateTime = new DateTime(2020,11,20,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,15,20),
			EndDateTime = new DateTime(2020,11,20,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,17,25),
			EndDateTime = new DateTime(2020,11,20,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,19,30),
			EndDateTime = new DateTime(2020,11,20,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,20,22,40),
			EndDateTime = new DateTime(2020,11,20,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,9,0),
			EndDateTime = new DateTime(2020,11,21,10,21),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Toy Story"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,10,50),
			EndDateTime = new DateTime(2020,11,21,12,32),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Dazed and Confused"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,13,0),
			EndDateTime = new DateTime(2020,11,21,14,40),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Lego Movie"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,15,20),
			EndDateTime = new DateTime(2020,11,21,16,58),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Princess Bride"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,17,25),
			EndDateTime = new DateTime(2020,11,21,19,5),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Finding Nemo"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,19,30),
			EndDateTime = new DateTime(2020,11,21,22,11),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "Harry Potter and the Chamber of Secrets"),
		});
		AllShowings.Add(new Showing
		{
			StartDateTime = new DateTime(2020,11,21,22,40),
			EndDateTime = new DateTime(2020,11,21,23,49),
			Room = 2,
			SpecialEvent = False,
			Movie = db.Movies.FirstOrDefault(c => c.Title == "The Land Before Time"),
		});
		//loop through the list to add or update the showing
		try
		{
			foreach (Showing seedShowing in AllShowings)
			{
				//update the counters
				intShowingID = seedShowing.ShowingID;
				strShowingTitle = seedShowing.Title;
				//see if the showing is already in the database using the UniqueIdentifier
				Showing dbShowing = db.Showings.FirstOrDefault(m => m.UniqueIdentifier == seedShowing.UniqueIdentifier);

					//if showing is null, showing is not in database
					if (dbShowing == null)
					{
						//Add the showing to the database
						db.Showings.Add(seedShowing);
						db.SaveChanges();
					}
					else //the showing is in the database - reset all fields except ID and Unique Identifier
					{
						dbShowing.StartDateTime = seedShowing.StartDateTime;
						dbShowing.EndDateTime = seedShowing.EndDateTime;
						dbShowing.Room = seedShowing.Room;
						dbShowing.SpecialEvent = seedShowing.SpecialEvent;
						dbShowing.Movie = seedShowing.Movie;
						db.SaveChanges();
					}
				}
			}
			catch (Exception ex) //throw error if there is a problem in the database
			{
				StringBuilder msg = new StringBuilder();
				msg.Append("There was a problem adding the showing with the title: ");
				msg.Append(strShowingTitle);
				msg.Append(" (ShowingID: ");
				msg.Append(intShowingID);
				msg.Append(")");
				throw new Exception(msg.ToString(), ex);
			}
		}
	}
}

		