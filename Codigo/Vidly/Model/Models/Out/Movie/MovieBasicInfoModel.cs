using Domain;

namespace Model.Out
{
    public class MovieBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rank { get; set; }

        public MovieBasicInfoModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Image = movie.Image;
            this.Rank = movie.Rank;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            if(obj is MovieBasicInfoModel movie)
            {
                result = this.Id == movie.Id && this.Name.Equals(movie.Name);
            }

            return result;
        }
    }
}