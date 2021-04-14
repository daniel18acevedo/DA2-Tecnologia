using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private DbConnection connection;
        
        private VidlyContext context;

        public MovieRepositoryTest()
        {
            this.connection = new SqliteConnection("Filename=:memory:");
            this.context = new VidlyContext(
                        new DbContextOptionsBuilder<VidlyContext>()
                        .UseSqlite(connection)
                        .Options);
        }

        [TestInitialize]
        public void Setup()
        {
            this.connection.Open();
            this.context.Database.EnsureCreated();
        } 
        
        [TestCleanup]
        public void CleanUp()
        {
            this.context.Database.EnsureDeleted();
        }

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
                    Duration = 1.5,
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Accion"
                    }
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
                        Id = 2,
                        Name = "Suspenso"
                    }
                }
            };

            /*
            Voy una vez a la BD
                Insert
                Insert
            */

            moviesToReturn.ForEach(m =>context.Add(m));

            context.SaveChanges(); 

            /*
                Voy a Bd
                Insert

                Voy a Bd
                Insert

             moviesToReturn.ForEach(m => 
             {
                 context.Add(m); 
                 context.SaveChanges();
                 });
            */

            var repository = new MovieRepository(context);

            var result = repository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));                  
        }

        [TestMethod]
        public void TestGetAllMoviesTwoOk()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Accion"
                },
                new Category
                {
                    Id = 2,
                    Name = "Suspenso"
                }
            };

            List<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Iron man 3",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5,
                    CategoryId = 1
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Iron man 2",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5,
                    CategoryId = 2
                }
            };

            /*
            Voy una vez a la BD
                Insert
                Insert
            */
            categories.ForEach(c => context.Add(c));

            moviesToReturn.ForEach(m =>context.Add(m));

            context.SaveChanges(); 

            /*
                Voy a Bd
                Insert

                Voy a Bd
                Insert

             moviesToReturn.ForEach(m => 
             {
                 context.Add(m); 
                 context.SaveChanges();
                 });
            */

            var repository = new MovieRepository(context);

            var result = repository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));                  
        }

        [TestMethod]
        public void TestEmptyDataBaseOk()
        {
            IEnumerable<Movie> movies = context.Movies.ToList();

            Assert.IsTrue(!movies.Any());
        }

        [TestMethod]
        public void TestGetMovieOk()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
                Category = new Category
                {
                    Id = 1,
                    Name = "Suspenso"
                }
            };
            this.context.Add(movie);
            this.context.SaveChanges();

            var repository = new MovieRepository(context);

            var result = repository.Get(1);

            Assert.AreEqual(movie, result);
        }

        [TestMethod]
        public void TestAddMovieToCategoryOk()
        {
            Category category = new Category
            {
                Id = 1,
                Name = "Intriga"
            };
            this.context.Add(category);

            Movie movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
                CategoryId = 1,
            };
            var repository = new MovieRepository(this.context);

            var result = repository.Add(movie);
            this.context.SaveChanges();

            Assert.AreEqual(repository.GetAll().Count(), 1);
        }

        //PascalCase
        //camelCase
        //snake_case
        [TestMethod]
        public void Test_Add_Movie_With_New_Category_Ok()
        {
            Movie movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
                Category = new Category
                {
                    Id = 1,
                    Name = "Intriga"
                }
            };
            var repository = new MovieRepository(this.context);

            var result = repository.Add(movie);
            this.context.SaveChanges();
            
            Assert.AreEqual(repository.GetAll().Count(), 1);
        }

        [TestMethod]
        public void TestUpdateMovieOk()
        {
            Category category = new Category
            {
                Id = 1,
                Name = "Suspenso"
            };
            this.context.Add(category);

            Movie movieFromDataBase = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            this.context.Add(movieFromDataBase);

            this.context.SaveChanges();
            
            Movie movie = new Movie
            {
                Id = 1,
                Name = "Elona Holmes 2"
            };
            
            VidlyContext newContext = new VidlyContext(
                        new DbContextOptionsBuilder<VidlyContext>()
                        .UseSqlite(connection)
                        .Options);
            var repository = new MovieRepository(newContext);

            repository.Update(movie);
            this.context.SaveChanges();

            Assert.AreEqual(repository.Get(1), movie);
        }

        [TestMethod]
        public void TestDeleteMovieOk()
        {
            Category category = new Category
            {
                Id = 1,
                Name = "Suspenso"
            };
            this.context.Add(category);

            Movie movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            this.context.Add(movie);
            this.context.SaveChanges();

            var repository = new MovieRepository(this.context);
            var movieToDelete = repository.Get(1);

            repository.Delete(movieToDelete);
            this.context.SaveChanges();

            Assert.AreEqual(repository.GetAll().Count(), 0);
        }
    }
}