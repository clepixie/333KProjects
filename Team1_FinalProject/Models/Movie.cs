using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Team1_FinalProject.Models
{
    public class Movie
    {

		public Int32 MovieID { get; set; }

		public string MovieName { get; set; }

		public DateTime MovieLength { get; set; }

		public string MovieDescription { get; set; }

		public Genre Genre { get; set; }

		public List<Showing> Showings { get; set; }
       
    }
}
