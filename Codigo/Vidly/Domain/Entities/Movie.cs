using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
        public int AgeAllowed { get; set; }
        public double Duration { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if(obj is Movie movie)
            {
                result = this.Id == movie.Id && this.Name.Equals(movie.Name);
            }

            return result;
        }
    }
}
