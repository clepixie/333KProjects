using System;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class CheckoutViewModel
    {
        public Order CurrentOrder { get; set; }
        public Boolean PCPoints { get; set; }
        public Boolean GiftSelection { get; set; }
        public String GiftEmail { get; set; }


    }
    
}
