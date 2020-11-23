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
		Unrated,
		NC17
	}

    public class Movie
    {

		public Int32 MovieID { get; set; }
		[Display(Name = "Movie #")]
		public Int32 MovieNumber { get; set; }
		[Display(Name = "Movie Title")]
		public string Title { get; set; }

		public Int32 Runtime { get; set; }

		public string Description { get; set; }
		[Display(Name = "MPAA Rating")]
		public MPAA MPAA { get; set; }

		[Display(Name = "Release Date")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyy}")]
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
		[Display(Name = "Movie Rating")]
		public decimal? AverageRating
		{
			get
			{
				decimal avg = 0;
				int count = 0;
				int sum = 0;
				if (Reviews is null)
				{
					return null;
				}

				else
				{
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
	}
}
