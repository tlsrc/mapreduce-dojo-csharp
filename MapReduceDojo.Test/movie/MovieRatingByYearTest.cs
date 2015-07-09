using MapReduceDojo.movie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapReduceDojo.Test.movie
{
    [TestClass]
    public class MovieRatingByYearTest {

        [TestMethod]
        public void ShouldFindHighestRatedMovieFor1994() {

            MovieDataSource dataSource = new MovieDataSource("movies.txt");
            MapReduceJob<Movie> job = new MapReduceJob<Movie>(new MovieRatingByYear(), dataSource);

            Assert.AreEqual(job.GetResults()["1994"].Name, "The Shawshank Redemption");
        }


    }
}
