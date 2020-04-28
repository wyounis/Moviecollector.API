﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MovieCollector.API.Models
{
    public class Movie
    {
        [BsonElement]
        public string Title { get; set; }
        [BsonElement]
        public string Producer { get; set; }
        [BsonElement]
        public string Director { get; set; }
        [BsonId]
        public int Episode_Id { get; set; }
        [BsonElement]
        public DateTime Release_Date { get; set; }
        [BsonElement]
        public int Personal_Rating { get; set; }
        [BsonElement]
        public List<Character> Characters { get; set; }
    }
}
