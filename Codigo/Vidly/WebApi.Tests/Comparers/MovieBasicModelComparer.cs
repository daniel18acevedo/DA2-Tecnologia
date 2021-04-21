using System.Collections;
using Model.Out;

namespace WebApi.Tests
{
    public class MovieBasicModelComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            MovieBasicModel movieBasicExpected = x as MovieBasicModel;
            MovieBasicModel movieBasicReturned = x as MovieBasicModel;

            bool equals = movieBasicExpected.Id == movieBasicReturned.Id && 
                        movieBasicExpected.Name == movieBasicReturned.Name;

            return equals ? 0 : -1;
        }
    }
}