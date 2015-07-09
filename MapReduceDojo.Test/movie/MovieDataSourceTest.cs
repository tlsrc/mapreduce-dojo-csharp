using System.IO;
using MapReduceDojo.movie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapReduceDojo.Test.movie
{
    [TestClass]
    public class MovieDataSourceTest
    {
        [TestMethod]
        public void ShouldReadMovieFile()
        {
            MovieDataSource dataSource = new MovieDataSource("movie/movies.txt");
            Assert.AreEqual(dataSource.Size(), 999);
        }

        [TestMethod, ExpectedException(typeof(DirectoryNotFoundException))]
        public void ShouldThrowExceptionWhenFolderNotFound()
        {
            new MovieDataSource("folder/does/not/exist.txt");
        }

        [TestMethod, ExpectedException(typeof (FileNotFoundException))]
        public void ShouldThrowExceptionWhenFileNotFound()
        {
            new MovieDataSource("helloworld.txt");
        }
    }
}
