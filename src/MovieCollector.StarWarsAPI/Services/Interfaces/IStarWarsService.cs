using MovieCollector.StarWarsAPI.Models.DTM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollector.StarWarsAPI.Services.Interfaces
{
    public interface IStarWarsService
    {
        public Film FindFilm(string filmName);
    }
}
