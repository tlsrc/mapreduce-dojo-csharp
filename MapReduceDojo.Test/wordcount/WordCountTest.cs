using System;
using MapReduceDojo.WordCount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapReduceDojo.Test.wordcount
{
    [TestClass]
    public class WordCountTest
    {
        [TestMethod]
        public void ShouldCountWordsContainedInDataSource()
        {
            IDataSource dataSource = new WordCountDataSource();
            MapReduceJob<Int32> job = new MapReduceJob<Int32>(new WordCount());

            job.Run(dataSource);

            Assert.AreEqual(job.GetFinalResults("tom"), 2);
            Assert.AreEqual(job.GetFinalResults("kim"), 2);
            Assert.AreEqual(job.GetFinalResults("ian"), 2);
            Assert.AreEqual(job.GetFinalResults("nancy"), 1);
            Assert.AreEqual(job.GetFinalResults("bob"), 1);
        }


    }
}
