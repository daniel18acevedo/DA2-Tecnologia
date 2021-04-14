using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void TestGetAllMoviesOk()
        {
            List<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Iron man 3",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Iron man 2",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5
                }
            };
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(moviesToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var movies = okResult.Value as IEnumerable<MovieBasicInfoModel>;

            mock.VerifyAll();
            Assert.IsTrue(moviesToReturn.Select(m => new MovieBasicInfoModel(m)).SequenceEqual(movies));
        }

        [TestMethod]
        public void TestPostMovieOk()
        {
            MovieModel movieModel = new MovieModel()
            {
                Name = "Enola Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            Movie movieToReturn = new Movie()
            {
                Id = 1,
                Name = "Enola Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
                Rank = 0
            };
            var mock = new Mock<IMovieLogic>();
            mock.Setup(m => m.Add(It.IsAny<Movie>())).Returns(movieToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.Post(movieModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as MovieDetailInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new MovieDetailInfoModel(movieToReturn));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostMovieIncorrectCategory()
        {
            MovieModel movieModel = new MovieModel()
            {
                Name = "Enola Holmes",
                AgeAllowed = 12,
                CategoryId = 5000,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio"
            };

            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Movie>())).Throws(new Exception());
            var controller = new MovieController(mock.Object);

            var result = controller.Post(movieModel);
        }
    }
}