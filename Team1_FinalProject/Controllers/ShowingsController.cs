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
    [Authorize(Roles = "Manager")]
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
        [AllowAnonymous]
        public IActionResult Index()
        {
            var query = from m in _context.Showings
                        select m;
            List<Showing> showings = query.Include(m => m.Movie).ThenInclude(m => m.Genre).Include(m => m.Tickets).Where(m => m.StartDateTime >= DateTime.Now).OrderBy(m => m.StartDateTime).ToList();
            ViewBag.AllShowings = showings.Count();
            ViewBag.SelectedShowings = showings.Count();
            return View("Index", showings);
        }

        public IActionResult AllIndex()
        {
            var query = from m in _context.Showings
                        select m;
            List<Showing> showings = query.Include(m => m.Movie).ThenInclude(m => m.Genre).OrderBy(m => m.StartDateTime).ToList();
            ViewBag.AllShowings = showings.Count();
            ViewBag.SelectedShowings = showings.Count();
            return View("Index", showings);
        }

        // GET: Movies/Index
        [AllowAnonymous]
        public IActionResult DisplayShowingSearchResults(SearchViewModel svm)
        {
            TryValidateModel(svm);

            if (ModelState.IsValid == false) //something is wrong
            {
                ViewBag.AllAvailableMovies = GetAllAvailableMovies();
                return View("~/Views/Home/SearchShowings.cshtml");//send user back to inputs page
            }
            var query = from s in _context.Showings
                        select s;

            // from the beginning, we only want to display showings that are current
            query = query.Where(m => m.StartDateTime >= DateTime.Now);

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
                    query = query.Where(m => m.StartDateTime.TimeOfDay >= starts);
                }
            }

            if (svm.SearchShowingTimeEnd != null && svm.SearchShowingTimeStart == null)
            {
                TimeSpan ends = (TimeSpan)svm.SearchShowingTimeEnd;
                query = query.Where(m => m.EndDateTime.TimeOfDay <= ends);
            }

            if(svm.SelectMovieID != null)
            {
                query = query.Where(m => svm.SelectMovieID.Contains(m.Movie.MovieID));
            }

            List<Showing> SelectedShowings = query.Include(s => s.Movie).ThenInclude(m => m.Genre).Include(m => m.Tickets).ToList();
            ViewBag.AllShowings = _context.Showings.Count();
            ViewBag.SelectedShowings = SelectedShowings.Count();
            return View("Index", SelectedShowings.OrderBy(s => s.StartDateTime));
        }
        // GET: Showings/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
       
            Showing showing = await _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
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
            ViewBag.AllMovies = GetAllMovies();
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowingID,StartDateTime,Room,SpecialEvent")] Showing showing, int SelectedMovie)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            showing.Movie = _context.Movies.Find(SelectedMovie);
            showing.EndDateTime = showing.StartDateTime + TimeSpan.FromMinutes(showing.Movie.Runtime);
            showing.Price = GetPrice(showing);

            _context.Add(showing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Showings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.AllMovies = GetAllMovies();
            Showing showing = await _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefaultAsync(m => m.ShowingID == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ShowingID,StartDateTime,Room,SpecialEvent")] Showing showing, int SelectedMovie)
        {
            if (id != showing.ShowingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    showing.Movie = _context.Movies.Find(SelectedMovie);
                    showing.EndDateTime = showing.StartDateTime + TimeSpan.FromMinutes(showing.Movie.Runtime);
                    showing.Price = GetPrice(showing);

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

        private MultiSelectList GetAllAvailableMovies()
        {
            List<Movie> moviesList = _context.Movies.Where(m => m.Showings.Count() != 0).ToList();

            MultiSelectList movieSelectList = new MultiSelectList(moviesList.OrderBy(m => m.MovieID), "MovieID", "Title");

            return movieSelectList;

        }

        private Price GetPrice(Showing showing)
        {
            var prices = from p in _context.Prices
                         select p;
            Price price = new Price();
            if (showing.StartDateTime.TimeOfDay < new TimeSpan(17, 0, 0) && showing.StartDateTime.TimeOfDay >= new TimeSpan(12, 0, 0) && showing.StartDateTime.DayOfWeek == DayOfWeek.Tuesday)
            {
                prices = prices.Where(p => p.PriceType == PType.Tuesday);
                foreach (Price p in prices)
                {
                    price = p;
                }
            }

            if (showing.StartDateTime.TimeOfDay < new TimeSpan(12, 0, 0) && showing.StartDateTime.DayOfWeek >= DayOfWeek.Monday && showing.StartDateTime.DayOfWeek <= DayOfWeek.Friday)
            {
                prices = prices.Where(p => p.PriceType == PType.WeekdayMorning);
                foreach (Price p in prices)
                {
                    price = p;
                }
            }

            if ((showing.StartDateTime.TimeOfDay >= new TimeSpan(12, 0, 0) && (showing.StartDateTime.DayOfWeek == DayOfWeek.Monday || showing.StartDateTime.DayOfWeek == DayOfWeek.Wednesday || showing.StartDateTime.DayOfWeek == DayOfWeek.Thursday)) || (showing.StartDateTime.DayOfWeek == DayOfWeek.Tuesday && showing.StartDateTime.TimeOfDay >= new TimeSpan(17, 0, 0)))
            {
                prices = prices.Where(p => p.PriceType == PType.WeekdayAfternoon);
                foreach (Price p in prices)
                {
                    price = p;
                }
            }

            if ((showing.StartDateTime.TimeOfDay >= new TimeSpan(12, 0, 0) && showing.StartDateTime.DayOfWeek == DayOfWeek.Friday) || (showing.StartDateTime.DayOfWeek == DayOfWeek.Sunday || showing.StartDateTime.DayOfWeek == DayOfWeek.Saturday))
            {
                prices = prices.Where(p => p.PriceType == PType.Weekend);
                foreach (Price p in prices)
                {
                    price = p;
                }
            }

            return price;
        }
        private SelectList GetAllMovies()
        {
            List<Movie> movieList = _context.Movies.ToList();

            SelectList movieSelectList = new SelectList(movieList.OrderBy(m => m.MovieID), "MovieID", "Title");

            return movieSelectList;
        }
    }
}
