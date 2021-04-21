using System;
using System.Collections;
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
using WebApi.QueryParams;
using FluentAssertions;

namespace WebApi.Tests
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void Test_Get_All_Movies_Filtered_With_Filtered_Category_Suspenso_And_Year_2020_ShouldBeOk()
        {
            List<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Iron man 3",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5,
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Suspenso"
                    },
                    ReleaseDate = new DateTime(2020, 1, 1)
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Iron man 2",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5,
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Suspenso"
                    },
                    ReleaseDate = new DateTime(2012, 1, 1)

                }
            };
            MovieQueryParam queryParams = new MovieQueryParam
            {
                Category = "Suspenso",
                Year = 2020
            };
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAllFiltered(queryParams.Category, queryParams.Year)).Returns(moviesToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.GetAllMoviesFiltered(queryParams);
            var okResult = result as OkObjectResult;
            var movies = okResult.Value as IEnumerable<MovieBasicModel>;

            mock.VerifyAll();
            CollectionAssert.AreEqual(moviesToReturn.Select(movie => new MovieBasicModel(movie)).ToList(), movies.ToList(), new MovieBasicModelComparer());
        }

        [TestMethod]
        public void Test_Get_All_Movies_Filtered_With_Filtered_Category_Suspenso_And_Year_2020_With_FluentAssertion_ShouldBeOk()
        {
            List<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Iron man 3",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5,
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Suspenso"
                    },
                    ReleaseDate = new DateTime(2020, 1, 1)
                }
            };
            MovieQueryParam queryParams = new MovieQueryParam
            {
                Category = "Suspenso",
                Year = 2020
            };
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAllFiltered(queryParams.Category, queryParams.Year)).Returns(moviesToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.GetAllMoviesFiltered(queryParams);
            var okResult = result as OkObjectResult;
            var movies = okResult.Value as IEnumerable<MovieBasicModel>;

            mock.VerifyAll();
            movies.Should().SatisfyRespectively(
                first => 
                {
                    first.Id.Should().Be(1);
                    first.Name.Should().Be("Iron man 3");
                }
            );
        }

        [TestMethod]
        public void Test_Get_Movie_By_Id_With_Incorrect_Id_Should_Be_Wrong()
        {
            int movieId = 5000;

            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(movieId)).Throws(new NullReferenceException());
            var controller = new MovieController(mock.Object);

            var result = controller.GetMovieById(movieId);
            var response = result as ObjectResult;
            var statusCode = response.StatusCode;
            var body = response.Value;

            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
            Assert.AreEqual(body, $"La pelicula con id {movieId} no existe en el sistema");
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
            mock.Setup(m => m.Save(It.IsAny<Movie>())).Returns(movieToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.Create(movieModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as MovieDetailModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new MovieDetailModel(movieToReturn));
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
            mock.Setup(m => m.Save(It.IsAny<Movie>())).Throws(new Exception());
            var controller = new MovieController(mock.Object);

            var result = controller.Create(movieModel);
        }

        [TestMethod]
        public void Test_Update_Name_Of_Movie_ShouldBeOk()
        {
            MovieModel movieModel = new MovieModel
            {
                Name = "Enola Holmes 2",
            };
            int movieId = 1;
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<int>(), It.IsAny<Movie>()));
            var controller = new MovieController(mock.Object);

            var response = controller.Update(movieId, movieModel);
            var statusCodeResult = response as StatusCodeResult;

            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void Test_Delete_Movie_ShouldBeOk()
        {
            int movieId = 1;
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(movieId));
            var controller = new MovieController(mock.Object);

            var response = controller.DeleteById(movieId);
            var statusCodeResult = response as StatusCodeResult;

            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }
    }
}