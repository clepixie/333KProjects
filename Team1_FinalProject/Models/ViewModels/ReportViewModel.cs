using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class ReportViewModel
    {
        public enum decision
        {
            SeatSold, TotalRevenue, Both
        }
        public ReportViewModel()
        {
        }
        public decision Decision { get; set; }
        public bool PopcornPoints { get; set; }
        public Movie Movie { get; set; }
        public MPAA MPAA { get; set; }
        public string CustomerEmail { get; set; }
        [Display(Name = "Showing Date:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? SearchShowingDateStart { get; set; }
        [Display(Name = "to:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? SearchShowingDateEnd { get; set; }
        [Display(Name = "Showing Time:")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public TimeSpan? SearchShowingTimeStart { get; set; }
        [Display(Name = "to:")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public TimeSpan? SearchShowingTimeEnd { get; set; }



        //public List<Showing> Showings { get; set; }
        //public List<Ticket> Tickets { get; set; }
        //public List<Order> Orders { get; set; }

    }
}
