using System;
using System.Collections.Generic;

namespace MapReduceDojo.wordcount
{
    public class WordCount : IMapperReducer<Int32> {

        public void Map(IEmitter<Int32> emitter, String record) {

            foreach (String word in record.Split(' ')) {
                // Count each word, emit a count of one
            }
        }

        public void Reduce(IEmitter<Int32> emitter, String key, List<Int32> values) {
            Int32 total = 0;
            // Reduce all the values to a total for the key
            emitter.Emit(key, total);
        }
    }
}
