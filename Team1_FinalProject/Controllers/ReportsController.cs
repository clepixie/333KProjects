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

        public IActionResult DecisionReport()
        {

            return View();
        }

        
        private SelectList GetAllMovies()
        {
            List<Movie> moviesList = _context.Movies.Where(m => m.Showings.Count() != 0).ToList();
            List<Showing> allShowings = _context.Showings.ToList();

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
                                        .Include(o => o.Customer)
                                        .ToList();
            }


            if (svm.SelectedMPAA != null)
            {
                query = query.Where(t => t.Showing.Movie.MPAA == svm.SelectedMPAA);
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


            svm.SeatsSold = query.Where(t => t.Order.OrderHistory == OrderHistory.Past).Count();
            List<Ticket> tickets = query.Where(t => t.Order.OrderHistory == OrderHistory.Past).ToList();

            foreach (Ticket ticket in tickets)
            {
                svm.TotalRevenue += ticket.Order.PostDiscount;
            }
            ViewBag.SummarizedTickets = tickets;

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
        public async Task<IActionResult> CustomerSearch()
        {
            ViewBag.UserList = await GetAllUsers();
            return View();
        }
        [HttpPost]
        public IActionResult DisplayCustomerReport (ReportViewModel svm)
        {
            /*Dictionary<Customer, OrderAggregate> ordersByCust = new Dictionary<>();

            List<Order> orderList = async getOrders();

            foreach (Order order in orderList) {
                Customer cust = order.customer;
                OrderAggregate orderAgg = ordersByCust.get(cust);
                if (orderAgg == null)
                {
                    orderAgg = new OrderAggregate();
                }
                orderAgg.totalTickets += cust.numTickets;
                orderAgg.someOtherAggregateAmt += cust.whateverTheFuckElseTheCustomerHas;
            }

            return ordersByCust.values();
            */
            if (svm.SelectedCustomerID != null)
            {
                List<ReportViewModel> customerList = new List<ReportViewModel>();
                AppUser customer = _userManager.Users.Where(u => u.Email == customerList[svm.SelectedCustomerID].SelectCustomerName).First();
                List<Order> orders = _context.Orders.Include(o => o.Tickets)
                                            .ThenInclude(t => t.Showing)
                                            .ThenInclude(s => s.Movie)
                                            .Include(o => o.Tickets)
                                            .ThenInclude(t => t.Showing)
                                            .ThenInclude(s => s.Price).Where(o => o.Customer.UserName == customer.Email).ToList();


                foreach (Order order in orders)
                {
                    if (order.OrderHistory == OrderHistory.Past)
                    {
                        if (order.PopcornPointsUsed == false)
                        {
                            svm.TotalRevenue += order.PostDiscount;
                        }
                        else if (order.PopcornPointsUsed == true)
                        {
                            svm.SeatsSold += (order.Tickets.Count() * 100);
                        }
                    }
                }

                ViewBag.CustomerOrders = orders;
            }
            else
            {
                List<Order> orders = _context.Orders.Include(o => o.Tickets)
                                            .ThenInclude(t => t.Showing)
                                            .ThenInclude(s => s.Movie)
                                            .Include(o => o.Tickets)
                                            .ThenInclude(t => t.Showing)
                                            .ThenInclude(s => s.Price).ToList();
                ViewBag.CustomerOrders = orders;
            }
            
            return View();
        }

        public IActionResult PPReport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayPP(ReportViewModel rvm)
        {
            var query = from o in _context.Tickets
                        select o;
            if (rvm.PopcornPoints == true)
            {
                query = query.Where(o => o.Order.PopcornPointsUsed == true);
            }
            List<Ticket> tickets = query
                .Include(t => t.Order)
                .ThenInclude(o => o.Customer)
                .Include(t => t.Showing)
                .ThenInclude(s => s.Movie)
                .ToList();

            ViewBag.pptickets = tickets;
            return View(tickets);
        }
    }
}
