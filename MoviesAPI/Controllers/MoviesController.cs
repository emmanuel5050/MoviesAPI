using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DatabaseContext;
using MoviesAPI.DTOs;
using MoviesAPI.Entity;
using MoviesAPI.MoviesRepo;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesServices _services;
        public MoviesController(MoviesServices services)
        {
            _services = services;
        }

        [HttpPost("add-movie")]
        public IActionResult AddMovie([FromBody] AddMovieDto movie)
        {
            if (ModelState.IsValid)
            {
                var IsAdded = _services.AddMovie(movie);
                if (IsAdded) return Ok();
                
            }

            return BadRequest(ModelState);
        }

        [HttpGet("get-movies")]
        public IActionResult GetMovies()
        {
            var movies = _services.GetMovies();
            return Ok(movies);
        }

        [HttpGet("get-movie/{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _services.GetMovie(id);

            if (movie.Data == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }       

        [HttpPut("update-movie/{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updatedMovie)
        {
            var movie = _services.UpdateMovies(id, updatedMovie);

            if (movie.Data == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("delete-movie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _services.DeleteMovie(id);

            if (!movie)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
