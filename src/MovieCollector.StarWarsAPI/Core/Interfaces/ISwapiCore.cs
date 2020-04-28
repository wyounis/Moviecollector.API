using MovieCollector.StarWarsAPI.Models.DTM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPI.Core.Interfaces
{
    public interface ISwapiCore
    {
        public Task<FilmsResponse> GetFilms(string id);

        public Task<Character> GetCharacter(string id);

        public Task<FilmsResponse> FindFilm(string filmName);
    }
}
