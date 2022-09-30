using Vidly.WebApi.Domain;
using Vidly.WebApi.Models.In;
using Vidly.WebApi.Models.Out;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Filters;
using System.Collections.Generic;

namespace Vidly.WebApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [AuthorizationFilter]
    public class MovieController : ControllerBase
    {
        private readonly UserLogged userLogged;

        private static List<Movie> _movies = new List<Movie>()
        {
            new Movie() { Id = 1, Title = "El conjuro", Description = "De terror" },
            new Movie() { Id = 2, Title = "El conjuro 2", Description = "De terror 2" }
        };

        public MovieController(UserLogged userLogged)
        {
            this.userLogged = userLogged;
        }

        // Index - Get all movies (/api/movies)
        [HttpGet]
        public IActionResult GetMovies([FromQuery] MovieSearchCriteria searchCriteria)
        {
            var filteredMovies = _movies.Where(searchCriteria.Criteria);

            return Ok(userLogged);
        }

        // Show - Get specific movie (/api/movies/{id})
        [HttpGet("{movieId}", Name = "GetMovie")]
        public IActionResult GetMovie(int movieId)
        {
            var movieSaved = _movies.FirstOrDefault(m => m.Id == movieId);

            if (movieSaved == null)
            {
                return NotFound(new
                {
                    error = "MovieNotFound",
                    message = "The movie doesn't exist"
                });
            }

            var movieDetail = new MovieDetailModel(movieSaved);

            return Ok(movieDetail);
        }

        // Create - Create new movie (/api/movies)
        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieModel newMovie)
        {
            if (string.IsNullOrEmpty(newMovie.Name) || string.IsNullOrEmpty(newMovie.Description))
            {
                return BadRequest(new
                {
                    error = "IncompleteMovie",
                    message = "Missing information for the movie, please refer to the documentation of the API to see the requiered properties."
                });
            }

            var existMovie = _movies.Any(m => m.Title == newMovie.Name);

            if (existMovie)
            {
                return BadRequest(new
                {
                    error = "DuplicateMovieName",
                    message = "The movie name all ready exist"
                });
            }

            var movieToSave = new Movie
            {
                Id = _movies.Count() + 1,
                Title = newMovie.Name,
                Description = newMovie.Description
            };

            _movies.Add(movieToSave);
            var movieModel = new MovieDetailModel(movieToSave);

            return CreatedAtRoute("GetMovie", new { movieId = movieToSave.Id }, movieModel);
        }

        // Update - Update specific movie (/api/movies/{id})
        [HttpPut("{movieId}")]
        public IActionResult Update(int movieId, [FromBody] MovieModel updatedMovie)
        {
            if (string.IsNullOrEmpty(updatedMovie.Name) || string.IsNullOrEmpty(updatedMovie.Description))
            {
                return BadRequest(new
                {
                    error = "IncompleteMovie",
                    message = "Missing information for the movie, please refer to the documentation of the API to see the requiered properties."
                });
            }

            var movieSaved = _movies.FirstOrDefault(m => m.Id == movieId);

            if (movieSaved == null)
            {
                return NotFound(new
                {
                    error = "MovieNotFound",
                    message = "The movie doesn't exist"
                });
            }

            // Workaround - como no puedo editar el elemento directamente en List, lo elimino y lo vuelvo a insertar actualizado
            var newMovie = new Movie()
            {
                Id = movieSaved.Id,
                Description = updatedMovie.Description,
                Title = updatedMovie.Name
            };

            _movies.Remove(movieSaved);
            _movies.Add(newMovie);
            return Ok();
        }

        // Delete - Delete specific movie (/api/movies/{id})
        [HttpDelete("{movieId}")]
        public IActionResult Update(int movieId)
        {
            var movieSaved = _movies.FirstOrDefault(m => m.Id == movieId);

            if (movieSaved == null)
            {
                return NotFound(new
                {
                    error = "MovieNotFound",
                    message = "The movie doesn't exist"
                });
            }

            _movies.Remove(movieSaved);
            return Ok();
        }
    }
}
