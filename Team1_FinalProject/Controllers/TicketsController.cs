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

namespace Team1_FinalProject.Controllers
{
    public class TicketsController : Controller
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        //RoleAdminController constructor
        public TicketsController(AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //populate the values of the variables passed into the controller
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Tickets
        public IActionResult Index() //Shopping Cart
        {
            List<Ticket> Tickets = _context.Tickets
                .Include(t => t.Showing)
                .ThenInclude(s => s.Movie)
                .ToList();

            return View(Tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

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

        [HttpGet]
        public async Task<IActionResult> CreateFor(Int32 showingID)
        {
            ViewBag.AllCustomers = await GetAllUsers();
            CreateForViewModel cfvm = new CreateForViewModel();
            cfvm.SelectShowingID = showingID;
            return View(cfvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFor([Bind("SelectedCustomerID, SelectShowingID")] CreateForViewModel cfvm)
        {
            List<CreateForViewModel> customerList = new List<CreateForViewModel>();
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true) //user is in the role
                {
                    //add user to list of members
                    CreateForViewModel newcus = new CreateForViewModel();
                    newcus.SelectCustomerName = user.Email;   
                    customerList.Add(newcus);
                }
            }
            // find the orders that match the user selected; we have to first a) get the int idx selected b) map that idx to the Email in customerList
            // c) match that to the Emails of Customers

            // finds the user that matches the selected ID
            AppUser customer = _userManager.Users.Where(u => u.Email == customerList[cfvm.SelectedCustomerID].SelectCustomerName).First();
            // get list of orders belonging to that user
            List<Order> orders = _context.Orders.Where(o => o.Customer.Id == customer.Id).ToList();

            Order current_order = new Order();
            // see if any of that user's orders are active
            foreach (Order order in orders)
            {
                if (order.OrderHistory == OrderHistory.Future)
                {
                    current_order = order;
                }

                break;
            }

            current_order.OrderHistory = OrderHistory.Future;
            current_order.PopcornPointsUsed = false;
            current_order.GiftOrder = false;

            return RedirectToAction("Create", "Tickets", new { showingID = cfvm.SelectShowingID, orderID = current_order.OrderID });
        }

        private MultiSelectList GetAvailableSeats(Showing showing)
        {
            List<TicketViewModel> temptickets = new List<TicketViewModel>();
            List<string> allSeats = new List<string> { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5", "D1", "D2", "D3", "D4", "D5", "E1", "E2", "E3", "E4", "E5" };
            List<int> allSeatsID = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24};
            int idx = 0;

            foreach (string seat in allSeats)
            {
                TicketViewModel tempticket = new TicketViewModel();
                tempticket.SelectSeatID = allSeatsID[idx];
                tempticket.SelectSeatNumber = allSeats[idx];
                temptickets.Add(tempticket);
                idx += 1;
            }

            List<Ticket> tickets = _context.Tickets.ToList();
            foreach (Ticket ticket in tickets)
            {
                if (ticket.Showing.ShowingID == showing.ShowingID)
                {
                    temptickets.RemoveAll(t => t.SelectSeatNumber == ticket.SeatNumber);
                }
            }

            //use the MultiSelectList constructor method to get a new MultiSelectList
            MultiSelectList mslAllTickets = new MultiSelectList(temptickets, "SelectSeatID", "SelectSeatNumber");

            return mslAllTickets;
        }

        // GET: Tickets/Create
        [HttpGet]
        public IActionResult Create(Int32 showingID, int? orderID)
        {
            Showing showing = _context.Showings.Find(showingID);

            ViewBag.AllSeats = GetAvailableSeats(showing);
            TicketViewModel holdshowingID = new TicketViewModel();
            holdshowingID.SelectShowingID = showingID;
            if (User.IsInRole("Employee"))
            {
                holdshowingID.SelectOrderID = orderID;
            }
            return View(holdshowingID);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SelectedSeats, SelectShowingID, SelectOrderID")] TicketViewModel tvm)
        {
            Showing showing = _context.Showings.Find(tvm.SelectShowingID);

            if (ModelState.IsValid == false)
            {
                ViewBag.AllSeats = GetAvailableSeats(showing);
                return View();
            }
            if (User.IsInRole("Customer"))
            {
                List<Order> orders = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name).ToList();
                Order current_order = new Order();

                foreach (Order order in orders)
                {
                    if (order.OrderHistory == OrderHistory.Future)
                    {
                        current_order = order;
                    }

                    break;
                }

                current_order.OrderHistory = OrderHistory.Future;
                current_order.PopcornPointsUsed = false;
                current_order.GiftOrder = false;

                if (current_order.Tickets != null)
                {
                    foreach (Ticket ticket in current_order.Tickets)
                    {
                        if (ticket.Showing.Movie.MPAA == MPAA.R || ticket.Showing.Movie.MPAA == MPAA.NC17)
                        {
                            TimeSpan newdate = DateTime.Now.Subtract(current_order.Customer.Birthdate);

                            if (newdate.TotalDays < 6570)
                            {
                                return View("Error", new String[] { "You must be 18 to watch this film!" });
                            }
                        }
                    }

                    //sorting the tickets from earliest to latest and then comparing each start time to each end time of the next film
                    var sorted_tickets = current_order.Tickets.OrderBy(x => x.Showing.StartDateTime.TimeOfDay).ToList();

                    foreach (Ticket ticket in sorted_tickets)
                    {
                        if (ticket.Showing.StartDateTime >= showing.EndDateTime)
                        {
                            return View("Error", new String[] { "This movie overlaps with another movie in your cart!" });

                        }
                    }

                    foreach (Ticket ticket in current_order.Tickets)
                    {
                        if (ticket.Showing.Movie.MovieID == showing.Movie.MovieID)
                        {
                            if (ticket.Showing.ShowingID != showing.ShowingID)
                            {
                                return View("Error", new String[] { "This movie is already in your cart for another showing time!" });
                            }
                        }
                    }
                }

                foreach (int seatnumber in tvm.SelectedSeats)
                {
                    List<string> allSeats = new List<string> { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5", "D1", "D2", "D3", "D4", "D5", "E1", "E2", "E3", "E4", "E5" };
                    Ticket ticket = new Ticket();
                    ticket.Showing = showing;
                    ticket.SeatClaim = true;
                    ticket.Order = current_order;
                    ticket.SeatNumber = allSeats[seatnumber];
                    _context.Tickets.Add(ticket);
                    showing.Tickets.Add(ticket);
                    _context.SaveChanges();
                }
                return RedirectToAction("Checkout", "Orders");
            }

            else
            {
                Order current_order = _context.Orders.Find(tvm.SelectOrderID);

                if (current_order.Tickets != null)
                {
                    foreach (Ticket ticket in current_order.Tickets)
                    {
                        if (ticket.Showing.Movie.MPAA == MPAA.R || ticket.Showing.Movie.MPAA == MPAA.NC17)
                        {
                            TimeSpan newdate = DateTime.Now.Subtract(current_order.Customer.Birthdate);

                            if (newdate.TotalDays < 6570)
                            {
                                return View("Error", new String[] { "You must be 18 to watch this film!" });
                            }
                        }
                    }

                    //sorting the tickets from earliest to latest and then comparing each start time to each end time of the next film
                    var sorted_tickets = current_order.Tickets.OrderBy(x => x.Showing.StartDateTime.TimeOfDay).ToList();

                    foreach (Ticket ticket in sorted_tickets)
                    {
                        if (ticket.Showing.StartDateTime >= showing.EndDateTime)
                        {
                            return View("Error", new String[] { "This movie overlaps with another movie in your cart!" });

                        }
                    }

                    foreach (Ticket ticket in current_order.Tickets)
                    {
                        if (ticket.Showing.Movie.MovieID == showing.Movie.MovieID)
                        {
                            if (ticket.Showing.ShowingID != showing.ShowingID)
                            {
                                return View("Error", new String[] { "This movie is already in your cart for another showing time!" });
                            }
                        }
                    }
                }

                foreach (int seatnumber in tvm.SelectedSeats)
                {
                    List<string> allSeats = new List<string> { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5", "D1", "D2", "D3", "D4", "D5", "E1", "E2", "E3", "E4", "E5" };
                    Ticket ticket = new Ticket();
                    ticket.Showing = showing;
                    ticket.SeatClaim = true;
                    ticket.Order = current_order;
                    ticket.SeatNumber = allSeats[seatnumber];
                    _context.Tickets.Add(ticket);
                    showing.Tickets.Add(ticket);
                    _context.SaveChanges();
                }

                return RedirectToAction("Checkout", "Orders", new { id = current_order.OrderID });
            }
        }
        

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketID,SeatNumber")] Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }
    }
}
