using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbContext context;
        private readonly DbSet<Movie> movies;

        public MovieRepository(DbContext context)
        {
            this.context = context;
            this.movies = context.Set<Movie>();
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.movies;
        }

        public Movie Get(int id)
        {
            return this.movies.First(m => m.Id == id);
        }

        public Movie Add(Movie movie)
        {
            this.movies.Add(movie);

            return movie;
        }

        public void Update(Movie movie)
        {
            this.context.Entry<Movie>(movie).State = EntityState.Modified;
            this.context.Attach(movie);
        }

        public void Delete(Movie movie)
        {
            this.movies.Remove(movie);
        }
    }
}
