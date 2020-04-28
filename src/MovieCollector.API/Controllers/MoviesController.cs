using Microsoft.AspNetCore.Mvc;
using MovieCollector.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
            try
            {
                return Ok(await _service.GetMovies());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([Required]string movieName, [Required]int movieRating)
        {
            try
            {
                return Ok(await _service.AddMovie(movieName, movieRating));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicateNameException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}/{movieRating}")]
        public async Task<IActionResult> Patch(string id, int movieRating)
        {
            try
            {
                return Ok(await _service.UpdateMovie(id, movieRating));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _service.DeleteMovie(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
