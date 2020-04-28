using MongoDB.Driver;
using MovieCollector.API.Models;

namespace MovieCollector.API.Data
{
    public class MongoDbContext
    {
        protected IMongoDatabase database;
        protected MongoClient client;

        public MongoDbContext()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("MovieCollectorDb");
        }

        public virtual IMongoCollection<Movie> Movies
        {
            get
            {
                return database.GetCollection<Movie>("Movies");
            }
        }
    }
}
