using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;
using Team1_FinalProject.Utilities;


namespace Team1_FinalProject.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public IActionResult Index() //Order History
        {
            List<Order> Orders = new List<Order>();
            if (User.IsInRole("Manager") || User.IsInRole("Employee"))
            {
                Orders = _context.Orders.Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Movie)
                                        .Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Price)
                                        .ToList();
            }
            else
            {
                Orders = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name)
                                        .Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Movie)
                                        .Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Price)
                                        .ToList();
            }

            return View(Orders);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = _context.Orders
            .Include(ord => ord.Tickets)
            .ThenInclude(ord => ord.Showing)
            .Include(ord => ord.Customer)
            .FirstOrDefault(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            //make sure a customer isn't trying to look at someone else's order
            if (User.IsInRole("Admin") == false && order.Customer.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to edit this order!" });
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,GiftOrder,PopcornPoints,Date")] Order order)
        {
            if (ModelState.IsValid == false)
            {
                return View(order);
            }
            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,GiftOrder,PopcornPoints,Date")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public SelectList GetAllActiveOrders()
        {
            List<CheckoutForViewModel> cfvm = new List<CheckoutForViewModel>();
            List<Order> activeorders = _context.Orders.Include(o => o.Customer).Where(o => o.OrderHistory == OrderHistory.Future).ToList();
            foreach (Order o in activeorders)
            {
                CheckoutForViewModel temp = new CheckoutForViewModel();
                temp.SelectOrderID = o.OrderID;
                temp.SelectOrderName = o.Customer.UserName + ": Order " + o.OrderID.ToString();
                cfvm.Add(temp);
            }
            SelectList orderSelectList = new SelectList(cfvm.OrderBy(m => m.SelectOrderID), "SelectOrderID", "SelectOrderName");
            return orderSelectList;
        }

        [HttpGet]
        public IActionResult CheckoutFor()
        {
            ViewBag.AllOrders = GetAllActiveOrders();
            CheckoutForViewModel cfvm = new CheckoutForViewModel();
            return View(cfvm);
        }
        [HttpPost]
        public IActionResult CheckoutFor([Bind("SelectedOrderID")] CheckoutForViewModel cfvm)
        {
            return RedirectToAction("Checkout", "Orders", new { id = cfvm.SelectedOrderID });
        }
        // Checkout
        // add if statement to check if list of tickets is null , then send error 
        // also if statement for purchasing tickets of multiple showings for same movie
        public async Task<IActionResult> Checkout(int? id)
        {
            if (User.IsInRole("Manager") || User.IsInRole("Employee"))
            {
                if (id == null)
                {
                    return RedirectToAction("CheckoutFor", "Orders");
                }

                Order currorder = _context.Orders.Include(o => o.Tickets).ThenInclude(o => o.Showing)
                    .ThenInclude(o => o.Movie).Include(o => o.Tickets).ThenInclude(o => o.Showing)
                    .ThenInclude(o => o.Price).Include(o => o.Customer).FirstOrDefault(o => o.OrderID == id);
                List<Ticket> tickets = _context.Tickets.Where(t => t.Order.OrderID == currorder.OrderID).ToList();

                if (tickets.Count() == 0)
                {
                    return View("Error", new String[] { "Your cart is empty. Please choose what to purchase first" });

                }
                else
                {
                    currorder.Date = DateTime.Now;
                    currorder.OrderHistory = OrderHistory.Future;
                    currorder.PopcornPointsUsed = false;
                    currorder.GiftOrder = false;
                    currorder.GiftEmail = null;
                    await _context.SaveChangesAsync();
                    return View(currorder);
                }
            }
            else
            {
                Order currorder = _context.Orders.Include(o => o.Tickets).ThenInclude(o => o.Showing)
                    .ThenInclude(o => o.Movie).Include(o => o.Tickets).ThenInclude(o => o.Showing)
                    .ThenInclude(o => o.Price).Where(o => o.Customer.UserName == User.Identity.Name)
                    .Where(o => o.OrderHistory == OrderHistory.Future).FirstOrDefault();

                if (currorder == null)
                {
                    return View("Error", new String[] { "Your cart is empty. Please choose what to purchase first" });

                }
                else
                {
                    currorder.Date = DateTime.Now;
                    currorder.Customer = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    currorder.OrderHistory = OrderHistory.Future;
                    currorder.PopcornPointsUsed = false;
                    currorder.GiftOrder = false;
                    currorder.GiftEmail = null;
                    await _context.SaveChangesAsync();
                    return View(currorder);
                }
            }
        }

        

        // Review [GET]
        public IActionResult Review([Bind("OrderID, PopcornPointsUsed, GiftOrder, GiftEmail")] Order order)
        {
            Order currorder = _context.Orders.Include(o => o.Tickets).ThenInclude(o => o.Showing)
            .ThenInclude(o => o.Movie).Include(o => o.Tickets).ThenInclude(o => o.Showing)
            .ThenInclude(o => o.Price).Include(o => o.Customer).FirstOrDefault(o => o.OrderID == order.OrderID);
            ViewBag.Discount = "N/A";
            if (order.GiftOrder == false && order.GiftEmail != null)
            {
                return View("Error", new String[] { "If you want to checkout as a gift, make sure to check next to Gift Order!" });
            }

            else
            {
                currorder.GiftEmail = order.GiftEmail;
            }

            if ((DateTime.Now.Date - currorder.Customer.Birthdate).TotalDays >= 21900)
            {
                // we will use viewbags rn because they may want to make changes still; not yet confirmed. we will officially change the values when they do confirm
                Price discountprice = _context.Prices.Where(p => p.PriceType == PType.SeniorCitizen).FirstOrDefault();
                decimal discount = discountprice.PriceValue;
                ViewBag.Discount = discount;
                if (currorder.Tickets.Count() >= 2)
                {
                    ViewBag.DiscountDouble = discount * 2;
                    ViewBag.DiscountSubtotal = currorder.OrderSubtotal + (discount * 2);
                    ViewBag.DiscountTax = Math.Round(((currorder.OrderSubtotal + (discount * 2)) * .0875m), 2);
                    ViewBag.DiscountDiff = currorder.OrderSubtotal + discount * 2;
                    ViewBag.DiscountTotal = Math.Round(((currorder.OrderSubtotal + (discount * 2)) * (1 + .0875m)), 2);
                }
                else
                {
                    ViewBag.DiscountSubtotal = currorder.OrderSubtotal + (discount);
                    ViewBag.DiscountTax = Math.Round(((currorder.OrderSubtotal + (discount)) * .0875m), 2);
                    ViewBag.DiscountDiff = currorder.OrderSubtotal + discount;
                    ViewBag.DiscountTotal = Math.Round(((currorder.OrderSubtotal + (discount)) * (1 + .0875m)), 2);
                }
            }

            if ((order.PopcornPointsUsed == true && currorder.Tickets.Count() <= ((currorder.Customer.PopcornPoints) / 100)) || (order.PopcornPointsUsed == false))
            {
                currorder.PopcornPointsUsed = order.PopcornPointsUsed;
            }

            else
            {
                return View("Error", new String[] { "You do not have enough Popcorn Points to use for this order; you have " + currorder.Customer.PopcornPoints + " but you need " +
                    (currorder.Tickets.Count() * 100) + " to cover this order." });
            }

            _context.Orders.Update(currorder);
            _context.SaveChanges();

            return View(currorder);
        }

        //Cancel
        [HttpPost]
        public IActionResult CancelOrder(Order order)
        {
            order.OrderHistory = OrderHistory.Cancelled;
            return View("Index");
        }

        public IActionResult Confirmation([Bind("OrderID, Tax, OrderTotal, PopcornPointsUsed, OrderNumber")] Order order)
        {
            Order pastorder = _context.Orders.Include(o => o.Tickets).ThenInclude(o => o.Showing)
            .ThenInclude(o => o.Movie).Include(o => o.Tickets).ThenInclude(o => o.Showing)
            .ThenInclude(o => o.Price).Include(o => o.Customer).FirstOrDefault(o => o.OrderID == order.OrderID);
            pastorder.OrderHistory = OrderHistory.Past;
            ViewBag.Earned = 0;

            // if they used PC points
            if (order.PopcornPointsUsed == true)
            {
                int points = pastorder.Tickets.Count();
                pastorder.Customer.PopcornPoints -= points * 100;
            }

            // if they didn't use PC points
            else
            {
                int points = (int)Decimal.Truncate(pastorder.OrderTotal);
                ViewBag.Earned = points;
                pastorder.Customer.PopcornPoints += points;
            }

            _context.Orders.Update(pastorder);
            _context.SaveChanges();

            if (pastorder.GiftEmail != null)
            {
                Utilities.EmailMessaging.SendEmail(order.GiftEmail, "Ticket Purchase Confirmation", "Your friend " + pastorder.Customer.FirstName + " " + pastorder.Customer.LastName + " " + "bought you some tickets! You order number is: " + order.OrderNumber);
            }

            else
            {
                Utilities.EmailMessaging.SendEmail(pastorder.Customer.Email, "Ticket Purchase Confirmation", "We confirmed you just placed an order! You order number is: " + order.OrderNumber);
            }
            
            return View(pastorder);
        }

        // Gift Order
        public IActionResult Gift()
        {
            return View();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
        
