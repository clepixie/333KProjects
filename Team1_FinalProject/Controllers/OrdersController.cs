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
                    .ThenInclude(o => o.Price).FirstOrDefault(o => o.OrderID == id);
                List<Ticket> tickets = _context.Tickets.Where(t => t.Order.OrderID == currorder.OrderID).ToList();

                if (tickets.Count() == 0)
                {
                    return View("Error", new String[] { "Your Cart is Empty. Please choose what to purchase first" });

                }
                else
                {
                    currorder.Date = DateTime.Now;
                    currorder.OrderHistory = OrderHistory.Future;
                    currorder.PopcornPointsUsed = false;
                    currorder.GiftOrder = false;
                    await _context.SaveChangesAsync();
                    return View(currorder);
                }
            }
            else
            {
                Order currorder = _context.Orders.Include(o => o.Tickets).ThenInclude(o => o.Showing)
                    .ThenInclude(o => o.Movie).Include(o => o.Tickets).ThenInclude(o => o.Showing)
                    .ThenInclude(o => o.Price).Where(o => o.Customer.UserName == User.Identity.Name)
                    .Where(o => o.OrderHistory == OrderHistory.Future).First();
                List<Ticket> tickets = _context.Tickets.Where(t => t.Order.OrderID == currorder.OrderID).ToList();

                if (tickets.Count() == 0)
                {
                    return View("Error", new String[] { "Your Cart is Empty. Please choose what to purchase first" });

                }
                else
                {
                    currorder.Date = DateTime.Now;
                    currorder.Customer = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    currorder.OrderHistory = OrderHistory.Future;
                    currorder.PopcornPointsUsed = false;
                    currorder.GiftOrder = false;
                    await _context.SaveChangesAsync();
                    return View(currorder);
                }
            }
        }

        //ViewBag.AllTickets = GetAllTickets(tickets)
        //ViewBag.AllTickets = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name)
        //                                .Include(o => o.Tickets)
        //                                .ThenInclude(t => t.Showing)
        //                                .ThenInclude(s => s.Movie)
        //                                .ToList();


        // only read the gift recipent email if the checkbox is checked

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked)
        //        textBox1.Text = checkBox1.Text;
        //}

        //checkout [POST]
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel cvm, Boolean PopcornPointsUsed, Boolean GiftOrder, Order order)
        {
            if (ModelState.IsValid == false)
            {
                return View(cvm);
            }
            if (PopcornPointsUsed == true)
            {
                cvm.PCPoints = true;
            }
            if (GiftOrder == true)
            {
                cvm.GiftSelection = true;
            }

            return View(cvm);
        }

        // Review
        public IActionResult Review(CheckoutViewModel cvm, Order order, int? id)
        {
            Order currorder = _context.Orders.Include(o => o.Tickets).ThenInclude(o => o.Showing)
            .ThenInclude(o => o.Movie).Include(o => o.Tickets).ThenInclude(o => o.Showing)
            .ThenInclude(o => o.Price).FirstOrDefault(o => o.OrderID == id);
            return View(cvm);
        }


        //Cancel
        [HttpPost]
        public IActionResult CancelOrder(Order order)
        {
            order.OrderHistory = OrderHistory.Cancelled;
            return View("Index");
        }

        // Confirmation
        //pass in order number and send an email
        [HttpPost]
        public IActionResult Confirmation(Order order)
        {
            order.OrderHistory = OrderHistory.Past;
            Utilities.EmailMessaging.SendEmail(order.Customer.Email, "Ticket Purchase Confirmation", "Confirmed you just placed an order! You order number is: " + order.OrderNumber);
            return View(order);
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
        
