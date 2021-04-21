using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int AgeAllowed { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public int Rank { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
