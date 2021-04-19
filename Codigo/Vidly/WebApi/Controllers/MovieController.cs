using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.QueryParams;

namespace WebApi.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic moviesLogic;

        public MovieController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }

        [HttpGet]
        public IActionResult GetAllMoviesFiltered([FromQuery] MovieQueryParam movieQueryParam)
        {
            var movies = this.moviesLogic.GetAllFiltered(movieQueryParam.Category, movieQueryParam.Year);

            IEnumerable<MovieBasicModel> moviesBasic = movies.Select(movie => new MovieBasicModel(movie));

            return Ok(moviesBasic);
        }

        //GET movies/movieId
        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            var movie = this.moviesLogic.GetById(movieId);

            MovieDetailModel movieDetail = new MovieDetailModel(movie);

            return Ok(movieDetail);
        }

        [HttpPost]
        public IActionResult Create(MovieModel movie)
        {
            var movieSaved = this.moviesLogic.Save(movie.ToEntity());

            MovieDetailModel movieDetailed = new MovieDetailModel(movieSaved);

            return CreatedAtRoute("GetMovieById", movieDetailed.Id, movieDetailed);
        }

        [HttpPut("{movieId}")]
        public IActionResult Update(int movieId, MovieModel movie)
        {
            this.moviesLogic.Update(movieId, movie.ToEntity());

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        public IActionResult DeleteById(int movieId)
        {
            this.moviesLogic.Delete(movieId);
            return NoContent();
        }
    }
}
