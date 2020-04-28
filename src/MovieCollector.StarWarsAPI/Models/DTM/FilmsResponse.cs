using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollector.StarWarsAPI.Models.DTM
{
    public class FilmsResponse
    {
        public int? Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public Film[] Results { get; set; }
    }

    public class Film
    {
        public string Title { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public string Episode_Id { get; set; }
        public DateTime? Release_Date { get; set; }
        public string[] Characters { get; set; }
        public Character[] CharactersObj { get; set; }
    }
}
