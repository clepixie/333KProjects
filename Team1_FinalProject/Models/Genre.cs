using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }

        public String GenreName { get; set; }

        public List<Showing> Showings { get; set; }

        public Genre()
        {
            if (Showings == null)
            {
                Showings = new List<Showing>();
            }
        }

    }
}