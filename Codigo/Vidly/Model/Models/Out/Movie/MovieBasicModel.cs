using Domain;

namespace Model.Out
{
    public class MovieBasicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rank { get; set; }

        public MovieBasicModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Image = movie.Image;
            this.Rank = movie.Rank;
        }
    }
}