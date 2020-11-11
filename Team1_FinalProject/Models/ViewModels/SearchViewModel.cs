using System;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
namespace Team1_FinalProject.Models
=======

namespace Team1_FinalProject.Models.ViewModels
>>>>>>> fe5f9a8070edbe4e958a8e79867c5b840db46061
{
    public enum Ratings
	{
		Greater,
		Lesser
	}

	public class SearchViewModel
    {
<<<<<<< HEAD
        [Display(Name = "Title:")]
		public string SearchTitle { get; set; }
		[Display(Name = "Tagline:")]
		public string SearchTagline { get; set; }
		[Display(Name = "Genre:")]
		public Int32 SelectGenreID { get; set; }
		[Display(Name = "Date:")]
		public DateTime? SearchDate { get; set; }
		[Display(Name = "MPAA Rating:")]
		public string SelectMPAA { get; set; } //enum
		[Display(Name = "Actor:")]
		public String SearchActor { get; set; }
		[Display(Name = "Customer Rating:")]
		[Range(1,5, ErrorMessage = "Rating must be between 1-5.")]
		public Decimal? SearchRating { get; set; }
		[Display(Name = "")]
		public Ratings? RatingRange { get; set; }
=======
		public enum Ratings
		{
			Greater,
			Lesser
		}
		
        public SearchViewModel()
        {
			[Display(Name = "Title:")]
			public string SearchTitle { get; set; }
			[Display(Name = "Tagline:")]
			public string SearchTagline { get; set; }
			[Display(Name = "Genre:")]
			public Int32 SelectGenreID { get; set; }
			[Display(Name = "Date:")]
			public DateTime? SearchDate { get; set; }
			[Display(Name = "MPAA Rating:")]
			public string SearchMPAA { get; set; }
			[Display(Name = "Actor:")]
			public SearchActor SearchActor { get; set; }
			[Display(Name = "Customer Rating:")]
			[Range(1,5, ErrorMessage = "Rating must be between 1-5.")]
			public Decimal? SearchRating { get; set; }
			[Display(Name = "")]
			public Ratings? RatingRange { get; set; }
        }
>>>>>>> fe5f9a8070edbe4e958a8e79867c5b840db46061
    }
}