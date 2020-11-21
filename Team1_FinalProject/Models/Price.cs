using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
namespace Team1_FinalProject.Models
{
    public enum Type
    {
        Showing,
        Discount
    }
    public class Price
    {
        public Int32 PriceID { get; set; }

        public string PriceTitle { get; set; }

        public Type PriceType { get; set; }

        public decimal PriceValue { get; set; }

        public List<Showing> Showings { get; set; }

    }
}
