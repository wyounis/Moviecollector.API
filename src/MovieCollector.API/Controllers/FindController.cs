using Microsoft.AspNetCore.Mvc;
using MovieCollector.API.Services.Interfaces;
using System.Threading.Tasks;

namespace MovieCollector.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/find")]
    public class FindController : Controller
    {
        public IMovieCollectorService _service;
        public FindController(IMovieCollectorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageOffset, int pageLimit)
        {
            return Ok(await _service.GetMovies(pageOffset, pageLimit));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string movieName, int movieRating)
        {
            return Ok(await _service.AddMovie(movieName, movieRating));
        }

        [HttpPut]
        public async Task<IActionResult> Put(string movieName, int movieRating)
        {
            return Ok(await _service.UpdateMovie(movieName, movieRating));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string movieName)
        {
            return Ok(await _service.DeleteMovie(movieName));
        }
    }
}
