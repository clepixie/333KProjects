using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;


namespace Team1_FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() 
        {
        }

        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public Int32 PopcornPoints { get; set; }

        public String Address { get; set; }

    }
}
