using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team1_FinalProject.Models
{
    public class CheckoutForViewModel
    {
        public int SelectOrderID { get; set; }
        [Required]
        [Display(Name = "Available Open Orders")]
        public string SelectOrderName { get; set; }
        public int SelectedOrderID { get; set; }
    }
}
