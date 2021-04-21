using System;
using System.Collections.Generic;
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

            Movie movie = new Movie
            {
                Name = "Iron man 4",
                AgeAllowed = 16,
                CategoryId = 1,
                Description = "Junto con batman pueden comprar al mundo",
                Duration = 2,
                Rank = 5,
                Countries = new List<Country>
                {
                    new Country
                    {
                        Id = 1,
                    }
                }
            };

            movies.Add(movie);
            context.SaveChanges();
        }
    }
}
