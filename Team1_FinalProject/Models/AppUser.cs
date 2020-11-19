using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;


namespace Team1_FinalProject.Models
{
    public class AppUser : IdentityUser
    {

        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        
        public String MiddleInitial { get; set; }

        public DateTime Birthdate { get; set; }

        public Int32 PopcornPoints { get; set; }

        public String Address { get; set; }

        public List<Order> Orders { get; set; }

        public List<MovieReview> MovieReviews { get; set; }

        public AppUser()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
			
			if (PopcornPoints == null)
			{
				PopcornPoints = 0;
			}
        }
    }
}
