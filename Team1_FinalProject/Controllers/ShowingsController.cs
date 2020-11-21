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
    public class ShowingsController : Controller
    {
        private readonly AppDbContext _context;

        public ShowingsController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        // GET: Showings
        public IActionResult Index()
        {
            var query = from m in _context.Showings
                        select m;
            ViewBag.AllShowings = _context.Showings.Count();
            ViewBag.SelectedShowings = _context.Showings.Count();
            return View("Index", query.Include(m => m.Movie).ThenInclude(m => m.Genre).OrderBy(m => m.StartDateTime).ToList());
        }
        // GET: Movies/Index
        public IActionResult DisplayShowingSearchResults(SearchViewModel svm)
        {
            TryValidateModel(svm);

            if (ModelState.IsValid == false) //something is wrong
            {
                return View("~/Views/Home/SearchMoviesShowings");//send user back to inputs page
            }
            var query = from s in _context.Showings
                        select s;

            if (svm.SearchShowingDateStart != null)
            {
                DateTime starts = (DateTime)svm.SearchShowingDateStart;
                if (svm.SearchShowingDateEnd != null)
                {
                    DateTime ends = (DateTime)svm.SearchShowingDateEnd;
                    query = query.Where(m => m.StartDateTime.Date >= starts && m.StartDateTime.Date <= ends);

                }

                else
                {
                    query = query.Where(m => m.StartDateTime.Date == starts);
                }
            }

            if (svm.SearchShowingDateEnd != null && svm.SearchShowingDateStart == null)
            {
                DateTime ends = (DateTime)svm.SearchShowingDateEnd;
                query = query.Where(m => m.EndDateTime.Date == ends);
            }

            if (svm.SearchShowingTimeStart != null)
            {
                TimeSpan starts = (TimeSpan)svm.SearchShowingTimeStart;
                if (svm.SearchShowingDateEnd != null)
                {
                    TimeSpan ends = (TimeSpan)svm.SearchShowingTimeEnd;
                    query = query.Where(m => m.StartDateTime.TimeOfDay >= starts && m.EndDateTime.TimeOfDay <= ends);

                }

                else
                {
                    query = query.Where(m => m.StartDateTime.TimeOfDay == starts);
                }
            }

            if (svm.SearchShowingTimeEnd != null && svm.SearchShowingTimeStart == null)
            {
                TimeSpan ends = (TimeSpan)svm.SearchShowingTimeEnd;
                query = query.Where(m => m.EndDateTime.TimeOfDay == ends);
            }

            List<Showing> SelectedShowings = query.Include(s => s.Movie).ThenInclude(m => m.Genre).ToList();
            ViewBag.AllShowings = _context.Showings.Count();
            ViewBag.SelectedShowings = SelectedShowings.Count();
            return View("Index", SelectedShowings.OrderBy(s => s.StartDateTime));
        }
        // GET: Showings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Showing showing = await _context.Showings
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .FirstOrDefaultAsync(m => m.ShowingID == id);

            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // GET: Showings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowingID,StartDateTime,EndDateTime,Room,SpecialEvent")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showing);
        }

        // GET: Showings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.Showings.FindAsync(id);
            if (showing == null)
            {
                return NotFound();
            }
            return View(showing);
        }

        // POST: Showings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowingID,StartDateTime,EndDateTime,Room,SpecialEvent")] Showing showing)
        {
            if (id != showing.ShowingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowingExists(showing.ShowingID))
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
            return View(showing);
        }

        // GET: Showings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.Showings
                .FirstOrDefaultAsync(m => m.ShowingID == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // POST: Showings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showing = await _context.Showings.FindAsync(id);
            _context.Showings.Remove(showing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowingExists(int id)
        {
            return _context.Showings.Any(e => e.ShowingID == id);
        }
    }
}
