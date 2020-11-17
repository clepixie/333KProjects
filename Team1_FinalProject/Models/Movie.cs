using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Team1_FinalProject.Models
{
	public enum MPAA
	{
		G,
		PG,
		PG13,
		R,
		Unrated
	}

    public class Movie
    {

		public Int32 MovieID { get; set; }

		public string MovieName { get; set; }

		public Int32 Runtime { get; set; }

		public string MovieDescription { get; set; }

		public MPAA MovieMPAA { get; set; }
		
		public string Actor { get; set; }

		public Int32 Revenue { get; set; }
		//apparently on the seeded data there is a column for this so i think
		// we need a property so we don't run into errors but we can hide it later
		// possibly thru the view

		public Genre Genre { get; set; }

		public List<Showing> Showings { get; set; }
       
    }
}
