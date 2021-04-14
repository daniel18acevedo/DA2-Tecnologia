using Domain;

namespace Model.In
{
    public class MovieModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int AgeAllowed { get; set; }

        public Movie ToEntity()
        {
            return new Movie()
            {
                Name = this.Name,
                AgeAllowed = this.AgeAllowed,
                CategoryId = this.CategoryId,
                Image = this.Image,
                Duration = this.Duration,
                Description = this.Description
            };
        }
    }
}