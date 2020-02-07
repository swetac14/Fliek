using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fliek.Models;
using Fliek.Dtos;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace Fliek.Controllers.Api
{
    public class MoviesController: ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();  
        }

        //GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movieResult= _context.Movies.Include(m=>m.GenreType).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieResult);
        }
        
        //GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.Add(Mapper.Map<MovieDto, Movie>(movieDto));
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id),movieDto);
        }

        //PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieDB == null)
                return NotFound();

            Mapper.Map(movieDto, movieDB);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}