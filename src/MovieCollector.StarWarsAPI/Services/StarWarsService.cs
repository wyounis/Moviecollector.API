using MovieCollector.StarWarsAPI.Core.Interfaces;
using MovieCollector.StarWarsAPI.Models.DTM;
using MovieCollector.StarWarsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPI
{
    public class StarWarsService : IStarWarsService
    {
        public ISwapiCore swapi;

        public StarWarsService(ISwapiCore swapi)
        {
            this.swapi = swapi;
        }

        [Obsolete]
        public async Task<Film> FindFilm(string filmName)
        {
            var filmList = new List<Film>();
            await PopulateFilmList(filmList);

            var Film = FindFilm(filmList, filmName);
            return Film;
        }

        public async Task<Film> FindFilm2(string filmName)
        {
            var films = await swapi.FindFilm(filmName);
            Film film = films?.results?.FirstOrDefault();
            if (film != null && film.characters != null)
            {
                foreach (var character in film.characters)
                {
                    Uri uri = new Uri(character);
                    film.characters_obj.Add(await swapi.GetCharacter(uri.Segments.Last()));
                }
            }
            return film;
        }

        #region Helpers
        private async Task PopulateFilmList(List<Film> films)
        {
            int startCounter = 1;

            var filmsResponse = await swapi.GetFilms(startCounter.ToString());
            films.AddRange(filmsResponse.results);

            while (filmsResponse.results != null)
            {
                startCounter++;
                filmsResponse = await swapi.GetFilms(startCounter.ToString());
                films.AddRange(filmsResponse.results);
            }
        }

        private Film FindFilm(List<Film> films, string filmName)
        {
            foreach (var film in films)
            {
                if (film.title.ToLowerInvariant() == filmName.ToLowerInvariant())
                    return film;
            }
            return null;
        }
        #endregion
    }
}
