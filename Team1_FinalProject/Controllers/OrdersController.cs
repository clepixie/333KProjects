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

namespace Team1_FinalProject.Controllers
{
    //[Authorize]
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
            if (User.IsInRole("Admin"))
            {
                Orders = _context.Orders.Include(o => o.Tickets).ToList();
            }
            else
            {
                Orders = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name)
                                        .Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Movie)
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


       

        // Checkout
        
        public async Task<IActionResult> Checkout(List<Ticket> tickets)
        {
            Order order = new Order();

            order.Tickets = tickets;

            if (ModelState.IsValid == false)
            {
                return View(order);
            }
            order.Date = DateTime.Now;

            order.Customer = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            order.OrderHistory = OrderHistory.Future;
            order.PopcornPointsUsed = false;
            order.GiftOrder = false;

            _context.Add(order);
            await _context.SaveChangesAsync();
            return View(order);


            /*ViewBag.AllTickets = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name)
                                        .Include(o => o.Tickets)
                                        .ThenInclude(t => t.Showing)
                                        .ThenInclude(s => s.Movie)
                                        .ToList();
             test the viewbag if the order instance doesn't work
             */       
            
            
        }

        //checkout [POST]
        [HttpPost]
        public IActionResult Checkout(Boolean PopcornPointsUsed, Boolean GiftOrder,Order order)
        {
            if (ModelState.IsValid == false)
            {
                return View(order);
            }
            if (PopcornPointsUsed == true)
            {
                order.PopcornPointsUsed = true;
            }
            if (GiftOrder == true)
            {
                order.GiftOrder = true;
            }

            return View(order);
        }

        // Review
        public IActionResult Review(Order order)
        {
            return View();
        }

        public IActionResult CancelOrder(Order order)
        {
            order.OrderHistory = OrderHistory.Cancelled;
            return View("Index");
        }

        // Confirmation
        public IActionResult Confirmation(Order order)
        {
            order.OrderHistory = OrderHistory.Past;
            return View();
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
