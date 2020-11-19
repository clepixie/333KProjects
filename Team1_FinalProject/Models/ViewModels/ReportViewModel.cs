using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Team1_FinalProject.Models
{
    public class ReportViewModel
    {
        public ReportViewModel()
        {
        }
        public Int32 SeatsSold { get; set; }
        public Decimal TotalRevenue { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Showing> Showings { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Order> Orders { get; set; }
        
    }
}
