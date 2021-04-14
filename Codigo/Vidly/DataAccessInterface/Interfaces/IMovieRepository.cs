using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DataAccessInterface
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
    }
}
