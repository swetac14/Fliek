using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fliek.Models;

namespace Fliek.Controllers
{
    public class MoviesController : Controller
    {

        List<Movie> MovieList = new List<Movie>()
            {
                new Movie { Id = 1, MovieName = "Finding Nemo", Genre = "family", ReleaseDate=DateTime.Now, Rating = "PG-13" },
                new Movie { Id = 2, MovieName = "Hidden Figures", Genre = "Sci-Fi",ReleaseDate=DateTime.Now, Rating = "PG-13" },
                new Movie { Id = 3, MovieName = "Bird Box", Genre = "Horror", ReleaseDate=DateTime.Now, Rating = "A" },
                new Movie { Id = 4, MovieName = "The week of", Genre = "comedy", ReleaseDate=DateTime.Now, Rating = "PG-13" },

        };

        // GET: Movies
        public ActionResult Index()
        {
            

            return View(MovieList);
        }

        [Route("movies/Release/{year}")]
        public ActionResult GetMoviesByYear(DateTime year)
        {
            var movie = MovieList.Where(m => m.ReleaseDate == DateTime.Now);

            return View(MovieList);
        }
    }
}