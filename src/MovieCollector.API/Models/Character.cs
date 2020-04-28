using MongoDB.Bson.Serialization.Attributes;

namespace MovieCollector.API.Models
{
    public class Character
    {
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Gender { get; set; }
        [BsonElement]
        public string Birth_Year { get; set; }
    }
}
