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

        public Movie Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.moviesRepository.GetAll();
        }
    }
}
