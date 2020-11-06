using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Team1_FinalProject.Models
{
    public class MovieReview
    {
        public MovieReview()
        {
			public MovieReviewID { get; set; }
			[Range(1, 5, ErrorMessage = "Rating must be between 1-5.")]
			public MovieRating { get; set; }
			[StringLength(280, ErrorMessage = "Character limit is 280 characters.")]
			public ReviewDescription { get; set; }
			public AppUser User { get; set; }
			public Movie Movie { get; set; }
        }
    }
}
