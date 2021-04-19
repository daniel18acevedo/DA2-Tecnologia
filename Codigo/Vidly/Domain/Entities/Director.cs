using System.Collections.Generic;

namespace Domain
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}