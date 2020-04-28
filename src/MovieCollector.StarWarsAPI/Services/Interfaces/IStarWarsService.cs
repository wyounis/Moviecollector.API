using MovieCollector.StarWarsAPI.Models.DTM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPI.Services.Interfaces
{
    public interface IStarWarsService
    {
        public Task<Film> FindFilm(string filmName);

        public Task<Film> FindFilm2(string filmName);
    }
}
