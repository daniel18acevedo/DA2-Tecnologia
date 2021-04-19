using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface IMovieLogic
    {
        IEnumerable<Movie> GetAllFiltered(string category, int year);
        Movie GetById(int movieId);
        Movie Save(Movie Movie);
        void Update(int movieId, Movie movie);
        void Delete(int movieId);
    }
}
