using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team1_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        // GET: Home/SearchSelect
        public IActionResult SearchSelect()
        {
            SearchViewModel svm = new SearchViewModel();
            return View("SearchSelect", svm);
        }
        // GET: Home/SearchMoviesShowings
        public IActionResult SearchMoviesShowings(SearchViewModel svm)
        {
            ViewBag.AllGenres = GetAllGenres();
            svm.SelectGenreID = 0;
            if (svm.MovieShowing == Select.Movie)
            {
                return View("SearchMovies", svm);
            }
            else
            {
                return View("SearchShowings", svm);
            }
        }

        private SelectList GetAllGenres()
        {
            List<Genre> genreList = _context.Genres.ToList();

            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            genreList.Add(SelectNone);

            SelectList genreSelectList = new SelectList(genreList.OrderBy(m => m.GenreID), "GenreID", "GenreName");

            return genreSelectList;
        }

        private SelectList GetAllMovies()
        {
            List<Movie> movieList = _context.Movies.ToList();

            Movie SelectNone = new Movie() { MovieID = 0, Title = "All Movies" };
            movieList.Add(SelectNone);

            SelectList movieSelectList = new SelectList(movieList.OrderBy(m => m.MovieID), "MovieID", "Title");

            return movieSelectList;
        }

        //[HttpPost]
        //public ActionResult DisplayReportsResults(ReportViewModel rvm) { }
    }
}
