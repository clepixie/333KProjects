using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team1_FinalProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ReportsController : Controller
    {
        // GET: /<controller>/
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ReportsController(AppDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult CustomerSearch()
        {
            return View();
        }
        private SelectList GetAllMovies()
        {
            List<Movie> moviesList = _context.Movies.Where(m => m.Showings.Count() != 0).ToList();
            List<Showing> allShowings = _context.Showings.ToList();
            /*
            foreach (Showing showing in allShowings)
            {
                // if a showing is older than today
                if (showing.StartDateTime < DateTime.Now)
                {
                    // first see if the showing's movie is still in the list; if not, go to next showing
                    if (moviesList.Contains(showing.Movie) == false)
                    {
                        continue;
                    }

                    bool nocurrent = true;
                    // check to see if that showing's movie has any current showings, meaning its start date is >= today
                    foreach (Showing mshowing in showing.Movie.Showings)
                    {
                        if (mshowing.StartDateTime >= DateTime.Now)
                        {
                            nocurrent = false;
                            break;
                        }
                    }
                    if (nocurrent == true)
                    {
                        moviesList.Remove(showing.Movie);
                    }
                }
            }
            */
            Movie SelectNone = new Movie() { MovieID = 0, Title = "All Movies" };
            moviesList.Add(SelectNone);
            SelectList movieSelectList = new SelectList(moviesList.OrderBy(m => m.MovieID), "MovieID", "Title");

            return movieSelectList;

        }

        [HttpPost]
        public IActionResult DisplayReport(ReportViewModel svm)
        {
            var query = from t in _context.Tickets
                        select t;
            List<Order> Orders = new List<Order>();
            {
                Orders = _context.Orders.Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Movie)
                                        .Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Price)
                                        .ToList();
            }


            if (svm.MPAA != null)
            {
                query = query.Where(t => t.Showing.Movie.MPAA==svm.MPAA);

            }

            if (svm.MovieTitle != null && svm.MovieTitle != "")
            {
                query = query.Where(t => t.Showing.Movie.Title.Contains(svm.MovieTitle));
            }

            if (svm.PopcornPoints)
            {
                query = query.Where(t => t.Order.PopcornPointsUsed == true);

            }

            if (svm.SearchShowingDateStart != null)
            {
                DateTime starts = (DateTime)svm.SearchShowingDateStart;
                if (svm.SearchShowingDateEnd != null)
                {
                    DateTime ends = (DateTime)svm.SearchShowingDateEnd;
                    query = query.Where(t => t.Showing.StartDateTime.Date >= starts && t.Showing.StartDateTime.Date <= ends);

                }

                else
                {
                    query = query.Where(t => t.Showing.StartDateTime.Date == starts);
                }
            }

            if (svm.SearchShowingDateEnd != null && svm.SearchShowingDateStart == null)
            {
                DateTime ends = (DateTime)svm.SearchShowingDateEnd;
                query = query.Where(t => t.Showing.EndDateTime.Date == ends);
            }

            if (svm.SearchShowingTimeStart != null)
            {
                TimeSpan starts = (TimeSpan)svm.SearchShowingTimeStart;
                if (svm.SearchShowingDateEnd != null)
                {
                    TimeSpan ends = (TimeSpan)svm.SearchShowingTimeEnd;
                    query = query.Where(t => t.Showing.StartDateTime.TimeOfDay >= starts && t.Showing.EndDateTime.TimeOfDay <= ends);

                }

                else
                {
                    query = query.Where(t => t.Showing.StartDateTime.TimeOfDay >= starts);
                }
            }

            if (svm.SearchShowingTimeEnd != null && svm.SearchShowingTimeStart == null)
            {
                TimeSpan ends = (TimeSpan)svm.SearchShowingTimeEnd;
                query = query.Where(t => t.Showing.EndDateTime.TimeOfDay <= ends);
            }

            if (svm.Movie != null && svm.Movie.MovieID != 0)
            {
                query = query.Where(t => t.Showing.Movie.MovieID == svm.Movie.MovieID);
            }

            if (svm.Decision == ReportViewModel.decision.SeatSold)
            {
                svm.SeatsSold = query.Where(t => t.Order.OrderHistory != OrderHistory.Cancelled).Count();
            }

            else if (svm.Decision == ReportViewModel.decision.TotalRevenue)
            {
                svm.TotalRevenue = query.Where(t => t.Order.OrderHistory != OrderHistory.Cancelled).Select(t => t.Order.OrderTotal).Sum();
            }
            else if (svm.Decision == ReportViewModel.decision.Both)
            {
                svm.SeatsSold = query.Where(t => t.Order.OrderHistory != OrderHistory.Cancelled).Count();
                svm.TotalRevenue = query.Where(t => t.Order.OrderHistory != OrderHistory.Cancelled).Select(t => t.Order.OrderTotal).Sum();
            }

            return View(svm);

        }

        //select list 
        private async Task<SelectList> GetAllUsers()
        {
            //Get the list of users from the database
            List<CreateForViewModel> customerList = new List<CreateForViewModel>();
            List<Int32> customerIDList = new List<Int32>();
            Int32 count = 0;
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true) //user is in the role
                {
                    //add user to list of members
                    CreateForViewModel newcus = new CreateForViewModel();
                    newcus.SelectCustomerName = user.Email;
                    newcus.SelectCustomerID = count;
                    customerIDList.Add(count);
                    customerList.Add(newcus);
                    count += 1;
                }
            }

            //convert the list to a SelectList by calling SelectList constructor
            //MonthID and MonthName are the names of the properties on the Month class
            //MonthID is the primary key
            SelectList customerSelectList = new SelectList(customerList, "SelectCustomerID", "SelectCustomerName");

            //return the electList
            return customerSelectList;
        }

        public IActionResult CustomerReportSearch (ReportViewModel svm)
        {
            var query = from t in _context.Tickets
                        select t;

            if (svm.CustomerEmail != null)
            {
                query = query.Where(t => t.Order.Customer.Email == svm.CustomerEmail);
            }

            query = query.Where(t => t.Order.PopcornPointsUsed == true);

            List <Ticket> CustomerSearchResults = query.Include(t => t.Order).ToList();

            return View("CustomerSearchResults", CustomerSearchResults.OrderByDescending(t => t.Order.Date));
        }
    }
}
