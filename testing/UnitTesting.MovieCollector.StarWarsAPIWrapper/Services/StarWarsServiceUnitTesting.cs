using Moq;
using MovieCollector.StarWarsAPI;
using MovieCollector.StarWarsAPI.Core.Interfaces;
using MovieCollector.StarWarsAPI.Models.DTM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting.MovieCollector.StarWarsAPIWrapper.Services
{
    public class StarWarsServiceUnitTesting
    {
        Mock<ISwapiCore> swapiCore;
        StarWarsService swService;
        public StarWarsServiceUnitTesting()
        {
            swapiCore = new Mock<ISwapiCore>();
            swService = new StarWarsService(swapiCore.Object);
        }
        [Fact]
        public async Task FindFilm2_FilmFound()
        {
            MockSwapiFindFilmSuccess();
            var film = await swService.FindFilm2("A New Hope");
            Assert.Equal("George Lucas", film.director);
            Assert.Equal(1, film.episode_id);
            Assert.Equal("Gary Kurtz, Rick McCallum", film.producer);
            Assert.Equal(new DateTime(1977, 05, 25), film.release_date);
            Assert.Equal("A New Hope", film.title);
            Assert.Equal("Luke Skywalker", film.characters_obj[0].name);
            Assert.Equal("male", film.characters_obj[0].gender);
            Assert.Equal("19BBY", film.characters_obj[0].birth_year);
        }

        [Fact]
        public async Task FindFilm2_FilmNotFound()
        {
            MockSwapiFindFilmFailure();
            var film = await swService.FindFilm2("Not found film");
            Assert.Null(film);
        }

        #region Helpers
        private void MockSwapiFindFilmSuccess()
        {
            FilmsResponse simulatedFilmResponse = new FilmsResponse
            {
                count = 1,
                next = null,
                previous = null,
                results = new List<Film>()
                {
                    new Film{
                        title = "A New Hope",
                        characters = new List<string>{ "http://swapi.dev/api/people/1/" },
                        director = "George Lucas",
                        episode_id = 1,
                        producer = "Gary Kurtz, Rick McCallum",
                        release_date = new DateTime( 1977,05,25)
                    }
                }
            };
            Character simulatedCharacter = new Character
            {
                name = "Luke Skywalker",
                gender = "male",
                birth_year = "19BBY"
            };
            swapiCore.Setup(sc => sc.FindFilm("A New Hope")).ReturnsAsync(simulatedFilmResponse);
            swapiCore.Setup(sc => sc.GetCharacter("1/")).ReturnsAsync(simulatedCharacter);
        }

        private void MockSwapiFindFilmFailure()
        {
            FilmsResponse simulatedFilmResponse = new FilmsResponse
            {
                count = 0,
                next = null,
                previous = null,
                results = null
            };
            swapiCore.Setup(sc => sc.FindFilm("Not found film")).ReturnsAsync(simulatedFilmResponse);
        }
        #endregion
    }
}
