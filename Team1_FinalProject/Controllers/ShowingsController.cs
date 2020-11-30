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

        public IActionResult PendingIndex()
        {
            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
            List<DateTime> nextweek = new List<DateTime>();
            DateTime today = DateTime.Now.Date;
            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                today = today.AddDays(1);
            }
            while (today.DayOfWeek != DayOfWeek.Friday)
            {
                today = today.AddDays(1);
            }

            foreach (int value in Enumerable.Range(1, 7))
            {
                nextweek.Add(today);
                today = today.AddDays(1);
            }
            ViewBag.Week = nextweek[0].ToString("MM/dd/yyyy") + "-" + nextweek[6].ToString("MM/dd/yyyy");
            return View(pending);
        }
        // GET: Showings
        [AllowAnonymous]
        public IActionResult Index()
        {
            var query = from m in _context.Showings
                        select m;
            List<Showing> showings = query.Include(m => m.Movie).ThenInclude(m => m.Genre).Include(m => m.Tickets).Where(m => m.StartDateTime >= DateTime.Now).Where(m => m.Status == SStatus.Published).OrderBy(m => m.StartDateTime).ToList();
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

            if (svm.SelectMovieID != null)
            {
                query = query.Where(m => svm.SelectMovieID.Contains(m.Movie.MovieID));
            }

            List<Showing> SelectedShowings = query.Include(s => s.Movie).ThenInclude(m => m.Genre).Include(m => m.Tickets).Where(m => m.Status == SStatus.Published).ToList();
            ViewBag.AllShowings = _context.Showings.Where(m => m.StartDateTime >= DateTime.Now).Where(m => m.Status == SStatus.Published).Count();
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

            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                today = today.AddDays(1);
            }

            while (today.DayOfWeek != DayOfWeek.Friday)
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
            _context.Showings.Add(showing);

            TimeSpan start = new TimeSpan(9, 0, 0);
            if (showing.StartDateTime.TimeOfDay < start)
            {
                ModelState.AddModelError(string.Empty, "You cannot add this showing because a showing cannot start earlier than 9:00 AM!");
                List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                List<DateTime> nw = new List<DateTime>();
                DateTime td = DateTime.Now.Date;

                while (td.DayOfWeek != DayOfWeek.Friday)
                {
                    td = td.AddDays(1);
                }

                foreach (int value in Enumerable.Range(1, 7))
                {
                    nw.Add(td);
                    td = td.AddDays(1);
                }
                ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                return View("PendingIndex", pending);
            }

            // get a sorted list of all the showings on the day you are trying to add this new showing in the same theater
            List<Showing> todayshowingt = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == showing.Room).OrderBy(s => s.StartDateTime).ToList();
            todayshowingt.Add(showing);
            List<Showing> todayshowing = todayshowingt.OrderBy(s => s.StartDateTime).ToList();

            int idx = todayshowing.FindIndex(s => s.ShowingID == showing.ShowingID);

            // first entry!
            if (todayshowing.Count() == 1)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("PendingIndex");
            }
            // it is the first showing of the day and it is not the last one
            if (idx == 0 && (todayshowing.Count() - 1) != idx)
            {
                if (showing.Room == todayshowing[idx + 1].Room && (((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (todayshowing[idx + 1].StartDateTime - todayshowing[idx + 1].EndDateTime).TotalMinutes > 0)))
                {
                    ModelState.AddModelError(string.Empty, "You cannot add this showing because it ends within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                    List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                    List<DateTime> nw = new List<DateTime>();
                    DateTime td = DateTime.Now.Date;

                    while (td.DayOfWeek != DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    foreach (int value in Enumerable.Range(1, 7))
                    {
                        nw.Add(td);
                        td = td.AddDays(1);
                    }
                    ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                    return View("PendingIndex", pending);
                }
            }

            // it is not the first nor last showing
            else if (idx != (todayshowing.Count() - 1))
            {

                if ((showing.Room == todayshowing[idx + 1].Room && ((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (todayshowing[idx + 1].EndDateTime - showing.StartDateTime).TotalMinutes > 0)) || (showing.Room == todayshowing[idx - 1].Room && ((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 0)))
                {
                    ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts or ends within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                    List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                    List<DateTime> nw = new List<DateTime>();
                    DateTime td = DateTime.Now.Date;

                    while (td.DayOfWeek != DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    foreach (int value in Enumerable.Range(1, 7))
                    {
                        nw.Add(td);
                        td = td.AddDays(1);
                    }
                    ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                    return View("PendingIndex", pending);
                    /*return View("Error", new String[] { "You cannot add this showing because it is too close with the existing showing:\n" + s.StartDateTime + " " + s.EndDateTime + "\n" + showing.StartDateTime + " " + showing.EndDateTime });*/
                }
            }

            // it is the last showing of the day
            else if (idx == (todayshowing.Count() - 1))
            {
                if (showing.Room == todayshowing[idx - 1].Room && (((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 0)))
                {
                    ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                    List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                    List<DateTime> nw = new List<DateTime>();
                    DateTime td = DateTime.Now.Date;

                    while (td.DayOfWeek != DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    foreach (int value in Enumerable.Range(1, 7))
                    {
                        nw.Add(td);
                        td = td.AddDays(1);
                    }
                    ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                    return View("PendingIndex", pending);
                }
            }

            List<Showing> todayshowingall = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).OrderBy(s => s.StartDateTime).ToList();

            foreach (Showing s in todayshowingall)
            {
                if (showing.StartDateTime == s.StartDateTime && s.Movie.Title == showing.Movie.Title && s.Room != showing.Room)
                {
                    ModelState.AddModelError(string.Empty, "You cannot schedule " + showing.Movie.Title + " at the same time in both Theaters on " + showing.StartDateTime + ".");
                    List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                    List<DateTime> nw = new List<DateTime>();
                    DateTime td = DateTime.Now.Date;

                    while (td.DayOfWeek != DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    foreach (int value in Enumerable.Range(1, 7))
                    {
                        nw.Add(td);
                        td = td.AddDays(1);
                    }
                    ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                    return View("PendingIndex", pending);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("PendingIndex");
        }

        public IActionResult Publish()
        {
            List<Showing> showings = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).OrderBy(s => s.StartDateTime).ToList();
            List<Showing> revshowings = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).OrderByDescending(s => s.StartDateTime).ToList();
            if (showings.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "There are no pending showings!");
                List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                List<DateTime> nw = new List<DateTime>();
                DateTime td = DateTime.Now.Date;

                while (td.DayOfWeek != DayOfWeek.Friday)
                {
                    td = td.AddDays(1);
                }

                foreach (int value in Enumerable.Range(1, 7))
                {
                    nw.Add(td);
                    td = td.AddDays(1);
                }
                ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                return View("PendingIndex", pending);
            }

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
            string sdays = "";
            foreach (DateTime day in days) { sdays += day.ToString("MM/dd/yyyy"); if (days.Count() > 1) { sdays += ", "; } }
            if (days.Count() != 7)
            {
                ModelState.AddModelError(string.Empty, "Some days are missing from your pending schedule; you only have: " + sdays);
                List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                List<DateTime> nw = new List<DateTime>();
                DateTime td = DateTime.Now.Date;

                while (td.DayOfWeek != DayOfWeek.Friday)
                {
                    td = td.AddDays(1);
                }

                foreach (int value in Enumerable.Range(1, 7))
                {
                    nw.Add(td);
                    td = td.AddDays(1);
                }
                ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                return View("PendingIndex", pending);
                /*return View("Error", new String[] { "Some days are missing from your pending schedule; you only have:\n" + sdays });*/
            }

            while (startdate != enddate)
            {
                List<List<Showing>> todayshowings = new List<List<Showing>>();
                List<Showing> todayshowing1 = showings.Where(s => s.StartDateTime.Date == startdate).Where(s => s.Room == 1).OrderBy(s => s.StartDateTime).ToList();
                todayshowings.Add(todayshowing1);
                List<Showing> todayshowing2 = showings.Where(s => s.StartDateTime.Date == startdate).Where(s => s.Room == 2).OrderBy(s => s.StartDateTime).ToList();
                todayshowings.Add(todayshowing2);

                if ((todayshowing1.Where(s => s.EndDateTime.TimeOfDay > new TimeSpan(21, 30, 0)) == null) && (todayshowing2.Where(s => s.EndDateTime.TimeOfDay > new TimeSpan(21, 30, 0)) == null))
                {
                    ModelState.AddModelError(string.Empty, "You must have one showing on " + startdate + " that ends after 9:30 PM");
                    List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                    List<DateTime> nw = new List<DateTime>();
                    DateTime td = DateTime.Now.Date;
                    if (td.DayOfWeek == DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    while (td.DayOfWeek != DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    foreach (int value in Enumerable.Range(1, 7))
                    {
                        nw.Add(td);
                        td = td.AddDays(1);
                    }
                    ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                    return View("PendingIndex", pending);
                    /*return View("Error", new String[] { "You must have one showing on " + startdate + " that ends after 9:30 PM" });*/
                }

                foreach (List<Showing> todayshowing in todayshowings)
                {
                    foreach (Showing showing in todayshowing)
                    {
                        int idx = todayshowing.FindIndex(s => s.ShowingID == showing.ShowingID);
                        try
                        {
                            if (((showing.StartDateTime - todayshowing[idx + 1].EndDateTime).TotalMinutes > 45) || ((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes > 45))
                            {
                                ModelState.AddModelError(string.Empty, "There are more than 45 minutes between " + showing.StartDateTime.ToString("HH:mm") + "-" + showing.EndDateTime.ToString("HH:mm") + " and " + todayshowing[idx + 1].StartDateTime.ToString("HH:mm") + "-" + todayshowing[idx + 1].EndDateTime.ToString("HH:mm") + " on " + showing.StartDateTime.Date.ToString("MM/dd/yyyy") + ".");
                                List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                                List<DateTime> nw = new List<DateTime>();
                                DateTime td = DateTime.Now.Date;
                                if (td.DayOfWeek == DayOfWeek.Friday)
                                {
                                    td = td.AddDays(1);
                                }
                                while (td.DayOfWeek != DayOfWeek.Friday)
                                {
                                    td = td.AddDays(1);
                                }

                                foreach (int value in Enumerable.Range(1, 7))
                                {
                                    nw.Add(td);
                                    td = td.AddDays(1);
                                }
                                ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                                return View("PendingIndex", pending);
                                /*return View("Error", new String[] { "There are more than 45 minutes between " + showing.StartDateTime.TimeOfDay + " and " + todayshowing[idx + 1].StartDateTime.TimeOfDay + "on" + showing.StartDateTime.Date + "." });*/
                            }

                        }
                        catch
                        {
                            continue;
                        }
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

            return RedirectToAction("Index");
        }
        private SelectList GetDaysShowings()
        {
            List<ScheduleViewModel> svm = new List<ScheduleViewModel>();
            List<int> dayID = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
            DateTime td = DateTime.Now;

            if (td.DayOfWeek == DayOfWeek.Friday)
            {
                td = td.AddDays(1);
            }

            while (td.DayOfWeek != DayOfWeek.Friday)
            {
                td = td.AddDays(1);
            }

            foreach (int id in dayID)
            {
                int showing = new List<Showing>(_context.Showings.Where(s => s.StartDateTime.Date == td.Date).ToList()).Count();
                ScheduleViewModel temp = new ScheduleViewModel();
                temp.DayDate = (td.ToString("MM/dd/yyyy") + ": " + td.DayOfWeek + "; " + "Showings #: " + showing);
                temp.DayID = id;
                svm.Add(temp);
                td = td.AddDays(1);
            }

            SelectList sldays = new SelectList(svm, "DayID", "DayDate");
            return sldays;
        }
        [HttpGet]
        public IActionResult CopySchedule()
        {
            ViewBag.FromDays = GetDaysShowings();
            ViewBag.ToDays = GetDaysShowings();
            return View();
        }

        [HttpPost]
        public IActionResult CopySchedule(int SelectedDateFrom, int SelectedDateTo)
        {
            List<int> dayID = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
            DateTime td = DateTime.Now.Date;

            if (td.DayOfWeek == DayOfWeek.Friday)
            {
                td = td.AddDays(1);
            }

            while (td.DayOfWeek != DayOfWeek.Friday)
            {
                td = td.AddDays(1);
            }

            DateTime selecteddateto = new DateTime();
            DateTime selecteddatefrom = new DateTime();
            foreach (int id in dayID)
            {
                if (id == SelectedDateFrom)
                {
                    selecteddatefrom = td;
                }
                if (id == SelectedDateTo)
                {
                    selecteddateto = td;
                }
                td = td.AddDays(1);
            }
            List<Showing> fromshow = _context.Showings.Where(s => s.StartDateTime.Date == selecteddatefrom.Date).ToList();
            List<Showing> toshow = _context.Showings.Where(s => s.StartDateTime.Date == selecteddateto.Date).ToList();

            if (fromshow.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "You cannot copy showings from a day that has no showings yet!");
                List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                List<DateTime> nw = new List<DateTime>();
                DateTime t = DateTime.Now.Date;
                if (td.DayOfWeek == DayOfWeek.Friday)
                {
                    td = td.AddDays(1);
                }
                while (t.DayOfWeek != DayOfWeek.Friday)
                {
                    t = t.AddDays(1);
                }

                foreach (int value in Enumerable.Range(1, 7))
                {
                    nw.Add(t);
                    t = t.AddDays(1);
                }
                ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                return View("PendingIndex", pending);
            }

            if (toshow.Count() != 0)
            {
                foreach (Showing s in toshow)
                {
                    _context.Showings.Remove(s);
                    _context.SaveChanges();
                }
            }

            // get the showings on the date you want to copy from
            List<Showing> copiedshowings = _context.Showings.Include(s => s.Movie).ThenInclude(s => s.Genre).Include(s => s.Price).Where(s => s.StartDateTime.Date == selecteddatefrom.Date).Where(s => s.Status == SStatus.Pending).ToList();
            foreach (Showing showing in copiedshowings)
            {
                Showing news = new Showing();
                // set the new showing to the copied showing
                // change relevant stuff like the start/end time and the price
                TimeSpan savetime = showing.StartDateTime.TimeOfDay;
                news.StartDateTime = selecteddateto + savetime;
                news.EndDateTime = news.StartDateTime + TimeSpan.FromMinutes(showing.Movie.Runtime);
                news.Price = GetPrice(news);
                news.Status = SStatus.Pending;
                news.Movie = showing.Movie;
                news.Room = showing.Room;
                news.SpecialEvent = showing.SpecialEvent;
                _context.Showings.Add(news);
                _context.SaveChanges();
            }

            return RedirectToAction("PendingIndex");
        }

        // GET: Showings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.AllMovies = GetAllMovies();
            Showing showing = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
            ViewBag.AllShowings1 = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == 1).OrderBy(s => s.StartDateTime).ToList();
            ViewBag.AllShowings2 = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == 2).OrderBy(s => s.StartDateTime).ToList();
            if (showing == null)
            {
                return NotFound();
            }
            return View(showing);
        }

        public IActionResult EditPending(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.NextWeekDays = GetAllDays();
            ViewBag.AllMovies = GetAllMovies();
            Showing showing = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
            ViewBag.AllShowings1 = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == 1).OrderBy(s => s.StartDateTime).ToList();
            ViewBag.AllShowings2 = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == 2).OrderBy(s => s.StartDateTime).ToList();
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
                ViewBag.AllMovies = GetAllMovies();
                return View(showing);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // first, find the first day of the next (unpublished) week
                    DateTime td = DateTime.Now.Date;
                    if (td.DayOfWeek == DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    while (td.DayOfWeek != DayOfWeek.Friday)
                    {
                        td = td.AddDays(1);
                    }

                    // if the new starting time is set to be on or after the first day of the next unpublished week, gotta redirect to EditPending
                    if (showing.StartDateTime.Date >= td)
                    {
                        return RedirectToAction("EditPending", new { id = showing.ShowingID });
                    }

                    showing.Movie = _context.Movies.Find(SelectedMovie);
                    showing.EndDateTime = showing.StartDateTime + TimeSpan.FromMinutes(showing.Movie.Runtime);
                    showing.Price = GetPrice(showing);
                    showing.Status = SStatus.Published;
                    _context.Update(showing);

                    TimeSpan start = new TimeSpan(9, 0, 0);
                    if (showing.StartDateTime.TimeOfDay < start)
                    {
                        ModelState.AddModelError(string.Empty, "You cannot add this showing because a showing cannot start earlier than 9:00 AM!");
                        ViewBag.AllMovies = GetAllMovies();
                        Showing show = _context.Showings
                                          .Include(o => o.Price)
                                          .Include(o => o.Movie)
                                          .ThenInclude(o => o.Genre)
                                          .Include(m => m.Tickets)
                                          .FirstOrDefault(m => m.ShowingID == id);
                        return View(show);
                    }

                    List<Showing> todayshowingt = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == showing.Room).OrderBy(s => s.StartDateTime).ToList();
                    todayshowingt.Add(showing);
                    List<Showing> todayshowing = todayshowingt.OrderBy(s => s.StartDateTime).ToList();

                    int idx = todayshowing.FindIndex(s => s.ShowingID == showing.ShowingID);

                    if (todayshowing.Count() == 1)
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    // this is the first showing but not the last one
                    if (idx == 0 && (todayshowing.Count() - 1) != idx)
                    {
                        if (showing.Room == todayshowing[idx + 1].Room && (((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (todayshowing[idx + 1].StartDateTime - todayshowing[idx + 1].EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it ends within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                        }

                        if (showing.Room == todayshowing[idx + 1].Room && (((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes > 45)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it ends over 45 minutes from another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                        }
                    }

                    // not the first or last showing
                    else if (idx != todayshowing.Count() - 1)
                    {

                        if ((showing.Room == todayshowing[idx + 1].Room && ((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (todayshowing[idx + 1].EndDateTime - showing.StartDateTime).TotalMinutes > 0)) || (showing.Room == todayshowing[idx - 1].Room && ((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts or ends within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                            /*return View("Error", new String[] { "You cannot add this showing because it is too close with the existing showing:\n" + s.StartDateTime + " " + s.EndDateTime + "\n" + showing.StartDateTime + " " + showing.EndDateTime });*/
                        }

                        if ((showing.Room == todayshowing[idx + 1].Room && ((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes > 45)) || (showing.Room == todayshowing[idx - 1].Room && ((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 45)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts or ends over 45 minutes from another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                            /*return View("Error", new String[] { "You cannot add this showing because it is too close with the existing showing:\n" + s.StartDateTime + " " + s.EndDateTime + "\n" + showing.StartDateTime + " " + showing.EndDateTime });*/
                        }
                    }

                    // the last showing
                    else if (idx == todayshowing.Count() - 1)
                    {
                        if (showing.Room == todayshowing[idx - 1].Room && (((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                        }

                        if (showing.Room == todayshowing[idx - 1].Room && (((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 45)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts over 45 minutes from another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                        }
                    }

                    List<Showing> todayshowingall = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).OrderBy(s => s.StartDateTime).ToList();

                    foreach (Showing s in todayshowingall)
                    {
                        if (showing.StartDateTime == s.StartDateTime && s.Movie.Title == showing.Movie.Title && s.Room != showing.Room)
                        {
                            ModelState.AddModelError(string.Empty, "You cannot schedule " + showing.Movie.Title + " at the same time in both Theaters on " + showing.StartDateTime + ".");
                            ViewBag.AllMovies = GetAllMovies();
                            Showing show = _context.Showings
                                              .Include(o => o.Price)
                                              .Include(o => o.Movie)
                                              .ThenInclude(o => o.Genre)
                                              .Include(m => m.Tickets)
                                              .FirstOrDefault(m => m.ShowingID == id);
                            return View(show);
                        }                     
                    }
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
            ViewBag.AllMovies = GetAllMovies();
            return View(showing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPending(int id, [Bind("ShowingID,StartDateTime,Room,SpecialEvent")] Showing showing, int SelectedMovie, int SelectedDate)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.NextWeekDays = GetAllDays();
                ViewBag.AllMovies = GetAllMovies();
                return View(showing);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int showid = showing.ShowingID;
                    List<DateTime> nextweek = new List<DateTime>();
                    DateTime today = DateTime.Now.Date + showing.StartDateTime.TimeOfDay;

                    while (today.DayOfWeek != DayOfWeek.Friday)
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
                    _context.Showings.Update(showing);

                    TimeSpan start = new TimeSpan(9, 0, 0);
                    if (showing.StartDateTime.TimeOfDay < start)
                    {
                        ModelState.AddModelError(string.Empty, "You cannot add this showing because a showing cannot start earlier than 9:00 AM!");
                        List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                        List<DateTime> nw = new List<DateTime>();
                        DateTime td = DateTime.Now.Date;
                        if (td.DayOfWeek == DayOfWeek.Friday)
                        {
                            td = td.AddDays(1);
                        }
                        while (td.DayOfWeek != DayOfWeek.Friday)
                        {
                            td = td.AddDays(1);
                        }

                        foreach (int value in Enumerable.Range(1, 7))
                        {
                            nw.Add(td);
                            td = td.AddDays(1);
                        }
                        ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                        return View("PendingIndex", pending);
                    }

                    List<Showing> todayshowingt = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).Where(s => s.Room == showing.Room).OrderBy(s => s.StartDateTime).ToList();
                    todayshowingt.Add(showing);
                    List<Showing> todayshowing = todayshowingt.OrderBy(s => s.StartDateTime).ToList();

                    int idx = todayshowing.FindIndex(s => s.ShowingID == showing.ShowingID);

                    if (todayshowing.Count() == 1)
                    {
                        _context.SaveChanges();
                        return RedirectToAction("PendingIndex");
                    }

                    if (idx == 0 && ((todayshowing.Count() - 1) != idx))
                    {
                        if (showing.Room == todayshowing[idx + 1].Room && (((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (todayshowing[idx + 1].StartDateTime - todayshowing[idx + 1].EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it ends within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                            List<DateTime> nw = new List<DateTime>();
                            DateTime td = DateTime.Now.Date;
                            if (td.DayOfWeek == DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }
                            while (td.DayOfWeek != DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }

                            foreach (int value in Enumerable.Range(1, 7))
                            {
                                nw.Add(td);
                                td = td.AddDays(1);
                            }
                            ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                            return View("PendingIndex", pending);
                        }
                    }
                    // this one is neither the first or last showing
                    else if (idx != (todayshowing.Count() -1))
                    {

                        if ((showing.Room == todayshowing[idx + 1].Room && ((todayshowing[idx + 1].StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (todayshowing[idx + 1].EndDateTime - showing.StartDateTime).TotalMinutes > 0)) || (showing.Room == todayshowing[idx - 1].Room && ((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts or ends within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                            List<DateTime> nw = new List<DateTime>();
                            DateTime td = DateTime.Now.Date;
                            if (td.DayOfWeek == DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }
                            while (td.DayOfWeek != DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }

                            foreach (int value in Enumerable.Range(1, 7))
                            {
                                nw.Add(td);
                                td = td.AddDays(1);
                            }
                            ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                            return View("PendingIndex", pending);
                            /*return View("Error", new String[] { "You cannot add this showing because it is too close with the existing showing:\n" + s.StartDateTime + " " + s.EndDateTime + "\n" + showing.StartDateTime + " " + showing.EndDateTime });*/
                        }
                    }

                    // this one is the last showing of the day
                    else if (idx == (todayshowing.Count() - 1))
                    {
                        if (showing.Room == todayshowing[idx - 1].Room && (((showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - todayshowing[idx - 1].EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts within 25 minutes with another showing: " + todayshowing[idx + 1].StartDateTime + " " + todayshowing[idx + 1].EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                            List<DateTime> nw = new List<DateTime>();
                            DateTime td = DateTime.Now.Date;
                            if (td.DayOfWeek == DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }
                            while (td.DayOfWeek != DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }

                            foreach (int value in Enumerable.Range(1, 7))
                            {
                                nw.Add(td);
                                td = td.AddDays(1);
                            }
                            ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                            return View("PendingIndex", pending);
                        }
                    }

                    List<Showing> todayshowingall = _context.Showings.Include(s => s.Movie).Where(s => s.StartDateTime.Date == showing.StartDateTime.Date).OrderBy(s => s.StartDateTime).ToList();

                    foreach (Showing s in todayshowingall)
                    {
                        if (showing.StartDateTime == s.StartDateTime && s.Movie.Title == showing.Movie.Title && s.Room != showing.Room)
                        {
                            ModelState.AddModelError(string.Empty, "You cannot schedule " + showing.Movie.Title + " at the same time in both Theaters on " + showing.StartDateTime + ".");
                            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                            List<DateTime> nw = new List<DateTime>();
                            DateTime td = DateTime.Now.Date;
                            if (td.DayOfWeek == DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }
                            while (td.DayOfWeek != DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }

                            foreach (int value in Enumerable.Range(1, 7))
                            {
                                nw.Add(td);
                                td = td.AddDays(1);
                            }
                            ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                            return View("PendingIndex", pending);
                        }
                    }
                    /*foreach (Showing s in todayshowing)
                    {
                        if (showing.Room == s.Room && (((showing.StartDateTime - s.EndDateTime).TotalMinutes < 25 && (showing.StartDateTime - s.EndDateTime).TotalMinutes > 0) || ((s.StartDateTime - showing.EndDateTime).TotalMinutes < 25 && (s.StartDateTime - showing.EndDateTime).TotalMinutes > 0)))
                        {
                            ModelState.AddModelError(string.Empty, "You cannot add this showing because it starts or ends within 25  minutes with another showing: " + s.StartDateTime + " " + s.EndDateTime + " and " + showing.StartDateTime + " " + showing.EndDateTime);
                            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                            List<DateTime> nw = new List<DateTime>();
                            DateTime td = DateTime.Now.Date;

                            while (td.DayOfWeek != DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }

                            foreach (int value in Enumerable.Range(1, 7))
                            {
                                nw.Add(td);
                                td = td.AddDays(1);
                            }
                            ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                            return View("PendingIndex", pending);
                            *//*return View("Error", new String[] { "You cannot add this showing because it is too close with the existing showing:\n" + s.StartDateTime + " " + s.EndDateTime + "\n" + showing.StartDateTime + " " + showing.EndDateTime });*//*
                        }

                        if (showing.StartDateTime == s.StartDateTime && s.Movie.Title == showing.Movie.Title && s.Room != showing.Room)
                        {
                            ModelState.AddModelError(string.Empty, "You cannot schedule " + showing.Movie.Title + " at the same time in both Theaters on " + showing.StartDateTime + ".");
                            List<Showing> pending = _context.Showings.Include(s => s.Movie).Where(s => s.Status == SStatus.Pending).ToList();
                            List<DateTime> nw = new List<DateTime>();
                            DateTime td = DateTime.Now.Date;

                            while (td.DayOfWeek != DayOfWeek.Friday)
                            {
                                td = td.AddDays(1);
                            }

                            foreach (int value in Enumerable.Range(1, 7))
                            {
                                nw.Add(td);
                                td = td.AddDays(1);
                            }
                            ViewBag.Week = nw[0].ToString("MM/dd/yyyy") + "-" + nw[6].ToString("MM/dd/yyyy");
                            return View("PendingIndex", pending);
                        }
                    }*/
                    _context.SaveChanges();
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
                return RedirectToAction("PendingIndex");
            }
            ViewBag.NextWeekDays = GetAllDays();
            ViewBag.AllMovies = GetAllMovies();
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
            return RedirectToAction("PendingIndex");
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
            List<string> nextweek = new List<string>();
            List<int> ids = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
            DateTime today = DateTime.Now.Date;

            while(today.DayOfWeek != DayOfWeek.Friday)
            {
                today = today.AddDays(1);
            }

            foreach (int value in Enumerable.Range(1, 7))
            {
                string stoday = today.ToString("MM/dd/yyyy");
                nextweek.Add(stoday);
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
