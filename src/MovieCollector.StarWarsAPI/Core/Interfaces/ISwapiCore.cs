using MovieCollector.StarWarsAPI.Models.DTM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPI.Core.Interfaces
{
    public interface ISwapiCore
    {
        public Task<IEnumerable<Film>> GetFilms();

        public Task<Character> GetCharacter(string id);
    }
}
