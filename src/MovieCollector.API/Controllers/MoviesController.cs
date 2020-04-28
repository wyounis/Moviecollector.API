using Microsoft.AspNetCore.Mvc;
using MovieCollector.API.Services.Interfaces;
using System.Threading.Tasks;

namespace MovieCollector.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Movies")]
    public class MoviesController : Controller
    {
        public IMovieCollectorService _service;
        public MoviesController(IMovieCollectorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetMovies());
        }

        [HttpPost]
        public async Task<IActionResult> Post(string movieName, int movieRating)
        {
            return Ok(await _service.AddMovie(movieName, movieRating));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Put(string id, int movieRating)
        {
            return Ok(await _service.UpdateMovie(id, movieRating));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _service.DeleteMovie(id));
        }
    }
}
