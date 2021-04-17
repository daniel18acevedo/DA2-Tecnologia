using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace BusinessLogicInterface
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int movieId);
        Movie Add(Movie movie);
    }
}
