﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using LevelUP.Dtos;
using LevelUP.Models;
using System.Data.Entity;
using System.Web.Routing;

namespace LevelUP.Controllers.Api

{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/Movies
       // public IEnumerable<MovieDto> GetMovies(string query = null)
        //{
          //  var moviesQuery = _context.Movies
            //    .Include(m => m.Genre)
              //  .Where(m => m.NumberAvailable > 0);

            //if (!String.IsNullOrWhiteSpace(query))
              //  moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            //return moviesQuery
              //  .ToList()
                //.Select(Mapper.Map<Movie, MovieDto>);
        //}
        public IHttpActionResult GetMovie()
        {
            //var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            //            if (movie == null)
            //              return NotFound();

            //        return Ok(Mapper.Map<Movie, MovieDto>(movie));
            var movieDtos = _context.Movies
                      .Include(c => c.Genre)
                      .ToList()
                      .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }


        // POST /api/movies/1
        [HttpPost]
      // [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //PUT/api/Movies/1
        [HttpPut]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }
        //Delete /api/Movies/1
        [HttpDelete]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
