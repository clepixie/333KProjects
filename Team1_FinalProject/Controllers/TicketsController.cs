using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;

namespace Team1_FinalProject.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
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

        private MultiSelectList GetAvailableSeats(Showing showing)
        {
            List<string> allSeats = new List<string> { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5", "D1", "D2", "D3", "D4", "D5", "E1", "E2", "E3", "E4", "E5" };
            List<Int32> allSeatsID = new List<Int32> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            if (showing.Tickets.Count() != 0)
            {
                List<Ticket> tickets = showing.Tickets.ToList();
                foreach (Ticket ticket in tickets)
                {
                    int index = allSeats.FindIndex(s => s == ticket.SeatNumber);
                    allSeats.Remove(ticket.SeatNumber);
                    allSeatsID.Remove(allSeatsID[index]);
                }
            }

            //use the MultiSelectList constructor method to get a new MultiSelectList
            MultiSelectList mslAllTickets = new MultiSelectList(allSeats);

            return mslAllTickets;
        }

        // GET: Tickets/Create
        [HttpGet]
        public IActionResult Create(Int32 showingID)
        {
            List<Ticket> new_tickets = new List<Ticket>();

            // find the order that should be associated with order id passed in param
            Showing showing = _context.Showings.Find(showingID);

            ViewBag.AllSeats = GetAvailableSeats(showing);
            
            foreach(Ticket ticket in new_tickets)
            {
                ticket.Showing = showing;
            }
            
            return View(new_tickets);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TicketID, SeatNumber, Order")] List<Ticket> tickets, int showingID, string[] SeatNumbers)
        { 
            if (ModelState.IsValid == false)
            {
                Showing showing = _context.Showings.Find(showingID);
                ViewBag.AllSeats = GetAvailableSeats(showing);
                return View(tickets);
            }
            
            List<Order> orders = _context.Orders.ToList();
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

            int idx = 0;
            foreach(Ticket ticket in tickets)
            {
                ticket.SeatClaim = true;
                ticket.Order = current_order;
                ticket.SeatNumber = SeatNumbers[idx];
                idx += 1;
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
            }

            return RedirectToAction("Checkout", "Orders", new { id = current_order.OrderID });
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
