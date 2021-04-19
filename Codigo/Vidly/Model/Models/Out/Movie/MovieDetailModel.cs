using Domain;

namespace Model.Out
{
    public class MovieDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public double Duration { get; set; }
        public int AgeAllowed { get; set; }
        public string Image { get; set; }

        public MovieDetailModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Description = movie.Description;
            this.Rank = movie.Rank;
            this.Duration = movie.Duration;
            this.AgeAllowed = movie.AgeAllowed;
            this.Image = movie.Image;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            if(obj is MovieDetailModel model)
            {
                result = model.Id == this.Id;
            }

            return result;
        }
    }
}