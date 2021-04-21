using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new VidlyContext();

            DbSet<Movie> movies = context.Set<Movie>();

            IList<int> countriesId = new List<int>
            {
                1,
                2
            };

            ICollection<Country> countries = context.Set<Country>().Where(country => countriesId.Contains(country.Id)).ToList();

            Movie movie = new Movie
            {
                Name = "Iron man vs Batman",
                AgeAllowed = 16,
                CategoryId = 1,
                Description = "Junto con batman pueden comprar al mundo",
                Duration = 2,
                Rank = 5,
                Countries = countries
            };

            movies.Add(movie);
            context.SaveChanges();
        }
    }
}
