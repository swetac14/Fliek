using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fliek.Models;
using Fliek.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Fliek.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            // var movies = _context.Movies.Include(c => c.GenreType).ToList();
            // return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("AdminIndex");
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var cust = _context.Movies.Include(c => c.GenreType).SingleOrDefault(c => c.Id == id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel()
            {
                //movie=  new Movie(),
                GenreTypes = genreTypes               

            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {           
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieDB.MovieName = movie.MovieName;
                movieDB.ReleaseDate = movie.ReleaseDate;
                movieDB.Rating = movie.Rating;
                movieDB.NumberInStock = movie.NumberInStock;
                movieDB.GenreId = movie.GenreId;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }



        [Route("movies/Release/{year}")]
        public ActionResult GetMoviesByYear(DateTime year)
        {

            return View();
        }
    }
}