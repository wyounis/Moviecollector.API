using MovieCollector.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollector.API.Services.Interfaces
{
    public interface IMovieCollectorService
    {
        public Task<IEnumerable<Movie>> GetMovies();
        public Task<Movie> GetMovie(string movieName);
        public Task<Movie> AddMovie(string movieName, int rating);
        public Task<Movie> UpdateMovie(string id, int rating);
        public Task<Movie> DeleteMovie(string id);
    }
}
