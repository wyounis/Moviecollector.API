using MovieCollector.API.Models;
using MovieCollector.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollector.API.Services
{
    public class MovieCollectorService : IMovieCollectorService
    {
        public async Task<IEnumerable<Movie>> GetMovies(int pageId, int pageLimit)
        {
            throw new NotImplementedException();
        }
        public async Task<Movie> GetMovie(string movieName)
        {
            throw new NotImplementedException();
        }
        public async Task<Movie> AddMovie(string movieName, int rating)
        {
            throw new NotImplementedException();
        }
        public async Task<Movie> UpdateMovie(string movieName, int rating)
        {
            throw new NotImplementedException();
        }
        public async Task<Movie> DeleteMovie(string movieName)
        {
            throw new NotImplementedException();
        }
    }
}
