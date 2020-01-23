using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fliek.Models;
using System.Data.Entity;

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

            var movies = _context.Movies.Include(c => c.GenreType).ToList();
            return View(movies);
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


        [Route("movies/Release/{year}")]
        public ActionResult GetMoviesByYear(DateTime year)
        {

            return View();
        }
    }
}