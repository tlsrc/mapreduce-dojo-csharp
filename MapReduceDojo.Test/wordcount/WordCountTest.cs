using System;
using MapReduceDojo.wordcount;
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

            MapReduceJob<Int32> job = new MapReduceJob<Int32>(new WordCount(), dataSource);

            Assert.AreEqual(job.GetResults()["tom"], 2);
            Assert.AreEqual(job.GetResults()["kim"], 2);
            Assert.AreEqual(job.GetResults()["ian"], 2);
            Assert.AreEqual(job.GetResults()["nancy"], 1);
            Assert.AreEqual(job.GetResults()["bob"], 1);
        }


    }
}
