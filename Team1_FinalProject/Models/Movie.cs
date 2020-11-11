using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Team1_FinalProject.Models
{
	// define enum for MPAA

    public class Movie
    {

		public Int32 MovieID { get; set; }

		public string MovieName { get; set; }

		public DateTime MovieLength { get; set; }

		public string MovieDescription { get; set; }

		public string MovieMPAA { get; set; }
		// change to enum
		public string Actor { get; set; }

		public Int32 Runtime { get; set; }

		public Genre Genre { get; set; }

		public List<Showing> Showings { get; set; }
       
    }
}
