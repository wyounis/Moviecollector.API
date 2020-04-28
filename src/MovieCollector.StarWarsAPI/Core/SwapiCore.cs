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

        public Task<IEnumerable<Film>> GetFilms()
        {
            throw new NotImplementedException();
        }

        public Task<Character> GetCharacter(string id)
        {
            throw new NotImplementedException();
        }
    }
}
