using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MovieCollector.StarWarsAPI.Models.DTM
{
    public class FilmsResponse
    {
        [JsonProperty]
        public int? count { get; set; }

        [JsonProperty]
        public string next { get; set; }

        [JsonProperty]
        public string previous { get; set; }

        [JsonProperty]
        public List<Film> results { get; set; }
    }

    public class Film
    {
        [JsonProperty]
        public string title { get; set; }
        [JsonProperty]
        public string producer { get; set; }
        [JsonProperty]
        public string director { get; set; }
        [JsonProperty]
        public int? episode_id { get; set; }
        [JsonProperty]
        public DateTime? release_date { get; set; }
        [JsonProperty]
        public List<string> characters { get; set; }
        [JsonProperty]
        public List<Character> characters_obj { get; set; } = new List<Character>();
    }
}
