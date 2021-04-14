
using System.Linq;
using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic moviesLogic;

        public MovieController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }

        //api/movies
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.moviesLogic.GetAll().Select(m => new MovieBasicInfoModel(m)));
        }

        //api/movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get([FromRoute]int id)
        {
            return Ok();
        }

        //api/movies
        [HttpPost]
        public IActionResult Post([FromBody]MovieModel movieModel)
        {
            var movie = this.moviesLogic.Add(movieModel.ToEntity());
            return CreatedAtRoute("GetName",new {id = movie.Id }, new MovieDetailInfoModel(movie));
        }

        //api/movies/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]object movie)
        {
            return Ok();
        }

        //api/movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            return Ok();
        }

        //api/movies
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}