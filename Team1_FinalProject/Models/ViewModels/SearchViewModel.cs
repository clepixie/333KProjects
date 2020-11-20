using System;
using System.ComponentModel.DataAnnotations;

namespace Team1_FinalProject.Models

{
	public enum RatingsRange
	{
		Greater,
		Lesser
	}

	public enum Select
    {
		Movie,
		Showing
    }

	public class SearchViewModel
	{
		[Display(Name = "Title:")]
		public string SearchTitle { get; set; }
		[Display(Name = "Tagline:")]
		public string SearchTagline { get; set; }
		[Display(Name = "Genre:")]
		public Int32 SelectGenreID { get; set; }
		[Display(Name = "Showing Date:")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? SearchShowingDate { get; set; }
		[Display(Name = "Release Year:")]
		[DisplayFormat(DataFormatString = "{0:yyyy}")]
		public DateTime? SearchReleaseDate { get; set; }
		[Display(Name = "MPAA Rating:")]
		public MPAA? SelectMPAA { get; set; } 
		[Display(Name = "Actors:")]
		public String SearchActor { get; set; }
		[Display(Name = "Customer Rating:")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1-5.")]
		public Decimal? SearchRating { get; set; }
		[Display(Name = "")]
		public RatingsRange? RatingsRange { get; set; }
		public Select MovieShowing { get; set; }

	}
}
