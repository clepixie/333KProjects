using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Lin_Eric_HW4.Models
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

    }
}
