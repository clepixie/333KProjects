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
            return View("Index", query.Include(m => m.Genre).ToList());
        }
        // GET: Movies/Index
        public IActionResult DisplaySearchResults(SearchViewModel svm)
        {
            TryValidateModel(svm);

            if (ModelState.IsValid == false) //something is wrong
            {
                return View("SearchMoviesShowings");//send user back to inputs page
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

                if (svm.SearchReleaseDate != null)
                {
                    query = query.Where(m => m.ReleaseDate == svm.SearchReleaseDate);
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
                    query = query.Where(m => m.Tagline.Contains(svm.SearchActor));
                }

                List<Movie> SelectedMovies = query.Include(m => m.Genre).ToList();
                ViewBag.AllMovies = _context.Movies.Count();
                ViewBag.SelectedMovies = SelectedMovies.Count();
                return View("Index", SelectedMovies.OrderByDescending(m => m.MovieID));
            }

            else
            {
                var query = from s in _context.Showings
                           select s;
                if (svm.SearchShowingDate != null)
                {
                    query = query.Where(m => m.StartDateTime == svm.SearchShowingDate);
                }

                List<Showing> SelectedShowings = query.Include(s => s.Movie).Include(s => s.TicketCount).ToList();
                ViewBag.AllShowings = _context.Showings.Count();
                ViewBag.SelectedShowings = SelectedShowings.Count();
                return View("ShowingsIndex", SelectedShowings.OrderByDescending(s => s.StartDateTime));
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
