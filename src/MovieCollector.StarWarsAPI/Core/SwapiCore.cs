using MovieCollector.StarWarsAPI.Adapters;
using MovieCollector.StarWarsAPI.Core.Interfaces;
using MovieCollector.StarWarsAPI.Models.DTM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPI.Core
{
    public class SwapiCore : ISwapiCore
    {
        public SwapiAdapter adapter;

        public SwapiCore()
        {
            adapter = new SwapiAdapter();
        }

        public async Task<FilmsResponse> GetFilms(string id)
        {
            var films = await adapter.GetAsync<FilmsResponse>("api/films/" + id);
            return films;
        }

        public async Task<Character> GetCharacter(string id)
        {
            var character = await adapter.GetAsync<Character>("api/people/" + id);
            return character;
        }

        public async Task<FilmsResponse> FindFilm(string filmName)
        {
            var films = await adapter.GetAsync<FilmsResponse>("api/films/?search=" + filmName);
            return films;
        }
    }
}
