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
            ViewBag.NextWeekDays = GetAllDays();
            ViewBag.AllMovies = GetAllMovies();
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowingID,StartDateTime,Room,SpecialEvent")] Showing showing, int SelectedMovie, int SelectedDate)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            List<DateTime> nextweek = new List<DateTime>();
            DateTime today = DateTime.Now.Date + showing.StartDateTime.TimeOfDay;

            while (today.DayOfWeek != DayOfWeek.Sunday)
            {
                today = today.AddDays(1);
            }

            foreach (int value in Enumerable.Range(1, 7))
            {
                nextweek.Add(today);
                today = today.AddDays(1);
            }

            showing.StartDateTime = nextweek[SelectedDate];
            showing.Movie = _context.Movies.Find(SelectedMovie);
            showing.EndDateTime = showing.StartDateTime + TimeSpan.FromMinutes(showing.Movie.Runtime);
            showing.Price = GetPrice(showing);
            showing.Status = SStatus.Pending;

            List<Showing> todayshowing = _context.Showings.Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).OrderBy(s => s.StartDateTime).ToList();

            foreach (Showing s in todayshowing)
            {
                if (((showing.EndDateTime - s.StartDateTime).TotalMinutes < 25 && (showing.EndDateTime - s.StartDateTime).TotalMinutes > 0) || ((s.EndDateTime - showing.StartDateTime).TotalMinutes < 25 && (s.EndDateTime - showing.StartDateTime).TotalMinutes > 0))
                {
                    return View("Error", new String[] { "You cannot add this showing because it is too close with the existing showing:\n" + s.StartDateTime + " " + s.EndDateTime + "\n" + showing.StartDateTime + " " + showing.EndDateTime });
                }
            }

            _context.Add(showing);
            await _context.SaveChangesAsync();
            return RedirectToAction("PendingIndex");
        }

        public IActionResult Publish()
        {
            List<Showing> showings = _context.Showings.Where(s => s.Status == SStatus.Pending).OrderBy(s => s.StartDateTime).ToList();
            List<Showing> revshowings = _context.Showings.Where(s => s.Status == SStatus.Pending).OrderByDescending(s => s.StartDateTime).ToList();
            DateTime startdate = showings[0].StartDateTime.Date;
            DateTime enddate = revshowings[0].StartDateTime.Date;
            List<DateTime> days = new List<DateTime>();

            foreach (Showing showing in showings)
            {
                if (days.Contains(showing.StartDateTime.Date) == false)
                {
                    days.Add(showing.StartDateTime.Date);
                }
            }

            if (days.Count() != 7)
            {
                return View("Error", new String[] { "Some days are missing from your pending schedule; you only have:\n" + days });
            }

            while (startdate != enddate)
            {
                List<Showing> todayshowing = showings.Where(s => s.StartDateTime.Date == startdate).OrderBy(s => s.StartDateTime).ToList();

                if (todayshowing.Where(s => s.EndDateTime.TimeOfDay > new TimeSpan(21, 30, 0)) == null)
                {
                    return View("Error", new String[] { "You must have one showing on " + startdate + " that ends after 9:30 PM" });
                }

                foreach (Showing showing in todayshowing)
                {
                    int idx = todayshowing.FindIndex(s => s.ShowingID == showing.ShowingID);
                    try
                    {
                        if (((showing.EndDateTime - todayshowing[idx + 1].StartDateTime).TotalMinutes > 45) || ((todayshowing[idx + 1].EndDateTime - showing.StartDateTime).TotalMinutes > 45))
                        {
                            return View("Error", new String[] { "There are more than 45 minutes between " + showing.StartDateTime.TimeOfDay + " and " + todayshowing[idx + 1].StartDateTime.TimeOfDay + "on" + showing.StartDateTime.Date + "." });
                        }

                    }
                    catch
                    {
                        continue;
                    }
                }
                startdate = startdate.AddDays(1);
            }

            foreach (Showing showing in showings)
            {
                showing.Status = SStatus.Published;
                _context.Showings.Update(showing);
                _context.SaveChanges();
            }

            return View("Index");
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
            if (ModelState.IsValid == false)
            {
                return View(showing);
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

        private SelectList GetAllDays()
        {
            List<ScheduleViewModel> svm = new List<ScheduleViewModel>();
            List<DateTime> nextweek = new List<DateTime>();
            List<int> ids = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
            DateTime today = DateTime.Now.Date;

            while(today.DayOfWeek != DayOfWeek.Sunday)
            {
                today = today.AddDays(1);
            }

            foreach (int value in Enumerable.Range(1, 7))
            {
                nextweek.Add(today);
                today = today.AddDays(1);
            }

            foreach (int id in ids)
            {
                ScheduleViewModel temp = new ScheduleViewModel();
                temp.ScheduleID = id;
                temp.ScheduleDate = nextweek[id];
                svm.Add(temp);
            }

            SelectList movieSelectList = new SelectList(svm, "ScheduleID", "ScheduleDate");

            return movieSelectList;
        }

    }
}
