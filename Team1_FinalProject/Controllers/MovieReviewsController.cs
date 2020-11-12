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
    public class MovieReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public MovieReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovieReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieReviews.ToListAsync());
        }

        // GET: MovieReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieReview = await _context.MovieReviews
                .FirstOrDefaultAsync(m => m.MovieReviewID == id);
            if (movieReview == null)
            {
                return NotFound();
            }

            return View(movieReview);
        }

        // GET: MovieReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieReviewID,MovieRating,ReviewDescription")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieReview);
        }

        // GET: MovieReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieReview = await _context.MovieReviews.FindAsync(id);
            if (movieReview == null)
            {
                return NotFound();
            }
            return View(movieReview);
        }

        // POST: MovieReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieReviewID,MovieRating,ReviewDescription")] MovieReview movieReview)
        {
            if (id != movieReview.MovieReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieReviewExists(movieReview.MovieReviewID))
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
            return View(movieReview);
        }

        // GET: MovieReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieReview = await _context.MovieReviews
                .FirstOrDefaultAsync(m => m.MovieReviewID == id);
            if (movieReview == null)
            {
                return NotFound();
            }

            return View(movieReview);
        }

        // POST: MovieReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieReview = await _context.MovieReviews.FindAsync(id);
            _context.MovieReviews.Remove(movieReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieReviewExists(int id)
        {
            return _context.MovieReviews.Any(e => e.MovieReviewID == id);
        }
    }
}
