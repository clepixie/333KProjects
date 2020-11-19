﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Team1_FinalProject.Models
{
	public enum MPAA
	{
		Select,
		G,
		PG,
		PG13,
		R,
		Unrated
	}

    public class Movie
    {

		public Int32 MovieID { get; set; }

		public string Title { get; set; }

		public Int32 Runtime { get; set; }

		public string Description { get; set; }

		public MPAA MPAA { get; set; }

		public DateTime ReleaseDate { get; set; }

		public string Actors { get; set; }

		public string Tagline { get; set; }

		public Int32 Revenue { get; set; }
		//apparently on the seeded data there is a column for this so i think
		// we need a property so we don't run into errors but we can hide it later
		// possibly thru the view

		public Genre Genre { get; set; }

		public List<Showing> Showings { get; set; }
		public List<MovieReview> Reviews { get; set; }

		public decimal AverageRating()
		{
			decimal avg = 0;
			int count = 0;
			int sum = 0;

			foreach (MovieReview review in Reviews)
			{
				sum += review.MovieRating;
				count += 1;
				avg = sum / count;
			}

			return avg;
		}
	}
}
