using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollector.StarWarsAPI.Adapters
{
    public class SwapiAdapter : BasicWebAdapter
    {
        public SwapiAdapter() : base("https://swapi.dev") { }
    }
}
