using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebApi.Tests
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void GetAllMoviesTest()
        {
            //Arrange
            //Act
            //Assert

            IEnumerable<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Batman",
                    Description = "Protagonista -> Gucci",
                    AgeAllowed = 18,
                    Duration = 1.5 
                }
            };

            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(moviesToReturn);
            
            var controller = new MovieController(mock.Object);
            var result = controller.Get();

            var verb = result as OkObjectResult;
            var content = verb.Value as IEnumerable<Movie>;

            mock.VerifyAll();
        }
    }
}
