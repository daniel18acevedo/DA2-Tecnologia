using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieRepository moviesRepository;

        public MovieLogic(IMovieRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public void Delete(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllFiltered()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int movieId)
        {
            throw new NotImplementedException();
        }

        public Movie Save(Movie Movie)
        {
            throw new NotImplementedException();
        }

        public void Update(int movieId, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
