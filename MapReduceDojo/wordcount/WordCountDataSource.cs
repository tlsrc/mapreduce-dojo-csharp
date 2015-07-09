using System;
using System.Collections.Generic;
using System.Linq;

namespace MapReduceDojo.wordcount
{
    public class WordCountDataSource : IDataSource
    {
        private static readonly String[] DATA = { "tom kim ian", "nancy bob tom kim", "ian"};

        public IEnumerator<String> GetEnumerator()
        {
            return DATA.ToList().GetEnumerator();
        }

        public int Size() {
            return DATA.Length;
        }
    }
}
