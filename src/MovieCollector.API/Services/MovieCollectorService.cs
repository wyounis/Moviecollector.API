using MongoDB.Driver;
using MovieCollector.API.Data;
using MovieCollector.API.Models;
using MovieCollector.API.Services.Interfaces;
using MovieCollector.StarWarsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace MovieCollector.API.Services
{
    public class MovieCollectorService : IMovieCollectorService
    {
        private readonly MongoDbContext _db;
        private readonly IStarWarsService _swService;

        public MovieCollectorService(MongoDbContext db, IStarWarsService swService)
        {
            _db = db;
            _swService = swService;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var filter = Builders<Movie>.Filter.Empty;
            return (await _db.Movies.FindAsync(filter)).ToList();
        }

        public async Task<Movie> GetMovie(string movieName)
        {
            var film = await _swService.FindFilm2(movieName);
            if (film == null)
                throw new KeyNotFoundException("Movie wasn't found");

            var filter = Builders<Movie>.Filter.Eq(i => i.Title, film.title);

            var movie = (await _db.Movies.FindAsync(filter)).FirstOrDefault();
            return movie;
        }

        public async Task<Movie> AddMovie(string movieName, int rating)
        {
            var film = await _swService.FindFilm2(movieName);
            if (film == null)
                throw new KeyNotFoundException("Movie wasn't found");

            var filter = Builders<Movie>.Filter.Eq(i => i.Title, film.title);

            var movie = (await _db.Movies.FindAsync(filter)).FirstOrDefault();
            if (movie != null)
                throw new DuplicateNameException();

            movie = new Movie
            {
                Title = film.title,
                Personal_Rating = rating,
                Characters = film.characters_obj.Select(i => new Character { Name = i.name, Gender = i.gender, Birth_Year = i.birth_year }).ToList(),
                Director = film.director,
                Episode_Id = film.episode_id.Value,
                Producer = film.producer,
                Release_Date = film.release_date.Value
            };
            await _db.Movies.InsertOneAsync(movie);
            return movie;
        }

        public async Task<Movie> UpdateMovie(string id, int rating)
        {
            var filter = Builders<Movie>.Filter.Eq(i => i.Id, id);
            var movie = (await _db.Movies.FindAsync(filter)).FirstOrDefault();

            if (movie == null)
                throw new KeyNotFoundException("Movie wasn't found in the db");

            var updateFilter = Builders<Movie>.Update.Set(i => i.Personal_Rating, rating);
            movie.Personal_Rating = rating;
            await _db.Movies.UpdateOneAsync(filter, updateFilter);
            return movie;
        }

        public async Task<Movie> DeleteMovie(string id)
        {
            var filter = Builders<Movie>.Filter.Eq(i => i.Id, id);
            var movie = (await _db.Movies.FindAsync(filter)).FirstOrDefault();

            if (movie == null)
                throw new KeyNotFoundException("Movie wasn't found in the db");

            return await _db.Movies.FindOneAndDeleteAsync(filter);
        }
    }
}
