using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
namespace Team1_FinalProject.Models
{
    public class Price
    {
        public Int32 PriceID { get; set; }

        [Display(Name ="Matinee Price")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public Int32 MatineePrice
        { get { return OrderSubtotal + Tax; }; set; }

        [Display(Name = "Tuesday Discount Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Int32 DiscountPrice
        { get; set; }

        [Display(Name = "Regular Ticket Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Int32 BasePrice
        { get; set; }

        [Display(Name = "Weekend Discount Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Int32 WeekendPrice
        { get; set; }

        [Display(Name = "Senior Citizen Discount")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Int16 SeniorDiscount
        { get; set; }

        public List<Showing> Showings { get; set; }

        
    }
}
