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
    public class MoviesController : Controller
    {

        private readonly AppDbContext _context;
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var query = from m in _context.Movies
                        select m;
            ViewBag.AllMovies = _context.Movies.Count();
            ViewBag.SelectedMovies = _context.Movies.Count();
            return View("Index", query.Include(m => m.Genre).Include(m => m.Showings).OrderByDescending(m => m.Showings.Count()).ToList());
        }
        // GET: Movies/Index
        public IActionResult DisplaySearchResults(SearchViewModel svm)
        {
            TryValidateModel(svm);

            if (ModelState.IsValid == false) //something is wrong
            {
                return View("~/Views/Home/SearchMoviesShowings");//send user back to inputs page
            }

            if (svm.MovieShowing == Select.Movie)
            {
                var query = from m in _context.Movies
                            select m;
                if (svm.SearchTitle != null && svm.SearchTitle != "")
                {
                    query = query.Where(m => m.Title.Contains(svm.SearchTitle));
                }

                if (svm.SearchTagline != null && svm.SearchTagline != "")
                {
                    query = query.Where(m => m.Tagline.Contains(svm.SearchTagline));
                }

                if (svm.SearchReleaseDateStart != null)
                {
                    DateTime startr = (DateTime)svm.SearchReleaseDateEnd;
                    if (svm.SearchReleaseDateEnd != null)
                    {
                        DateTime endr = (DateTime)svm.SearchReleaseDateEnd;
                        foreach (DateTime day in EachDay(startr, endr))
                        {
                            query = query.Where(m => m.ReleaseDate.ToString("yyyy") == day.ToString("yyyy"));
                        }
                    }

                    else
                    {
                        query = query.Where(m => m.ReleaseDate.ToString("yyyy") == startr.ToString("yyyy"));
                    }
                }

                if (svm.SearchReleaseDateEnd != null)
                {
                    DateTime endr = (DateTime)svm.SearchReleaseDateEnd;
                    query = query.Where(m => m.ReleaseDate.ToString("yyyy") == endr.ToString("yyyy"));
                }

                if (svm.SelectGenreID != 0)
                {
                    query = query.Where(m => m.Genre.GenreID == svm.SelectGenreID);
                }

                if (svm.SelectMPAA != null)
                {
                    query = query.Where(m => m.MPAA == svm.SelectMPAA);
                }

                if (svm.SearchRating != null && svm.RatingsRange == null)
                {
                    query = query.Where(m => m.AverageRating == svm.SearchRating);
                }

                switch (svm.RatingsRange)
                {
                    case RatingsRange.Greater:
                        query = query.Where(m => m.AverageRating >= svm.SearchRating);
                        break;
                    case RatingsRange.Lesser:
                        query = query.Where(m => m.AverageRating <= svm.SearchRating);
                        break;
                    default:
                        break;
                }

                if (svm.SearchActor != null && svm.SearchActor != "")
                {
                    query = query.Where(m => m.Actors.Contains(svm.SearchActor));
                }

                List<Movie> SelectedMovies = query.Include(m => m.Genre).Include(m => m.Showings).ToList();
                ViewBag.AllMovies = _context.Movies.Count();
                ViewBag.SelectedMovies = SelectedMovies.Count();
                return View("Index", SelectedMovies.OrderByDescending(m => m.Showings.Count()));
            }

            else
            {
                var query = from s in _context.Showings
                           select s;

                if (svm.SearchShowingDateStart != null)
                {
                    DateTime starts = (DateTime)svm.SearchShowingDateEnd;
                    if (svm.SearchShowingDateEnd != null)
                    {
                        DateTime ends = (DateTime)svm.SearchShowingDateEnd;
                        foreach (DateTime day in EachDay(starts, ends))
                        {
                            query = query.Where(m => m.StartDateTime.ToString("MM/dd/yyyy") == day.ToString("MM/dd/yyyy"));
                        }

                    }

                    else
                    {
                        query = query.Where(m => m.StartDateTime.ToString("MM/dd/yyyy") == starts.ToString("MM/dd/yyyy"));
                    }
                }

                if (svm.SearchReleaseDateEnd != null)
                {
                    DateTime ends = (DateTime)svm.SearchShowingDateEnd;
                    query = query.Where(m => m.StartDateTime.ToString("MM/dd/yyyy") == ends.ToString("MM/dd/yyyy"));
                }

                List<Showing> SelectedShowings = query.Include(s => s.Movie).ThenInclude(m => m.Genre).ToList();
                ViewBag.AllShowings = _context.Showings.Count();
                ViewBag.SelectedShowings = SelectedShowings.Count();
                return View("~Views/Showings/Index", SelectedShowings.OrderBy(s => s.StartDateTime));
            }
        }
        // GET: Movies

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,Title,MovieLength,Description,MPAA,Actors,Runtime,AverageRating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,Title,MovieLength,Description,MPAA,Actors,Runtime")] Movie movie)
        {
            if (id != movie.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieID))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}
