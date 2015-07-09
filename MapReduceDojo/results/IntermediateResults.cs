using System;
using System.Collections.Generic;

namespace MapReduceDojo.results
{
    public class IntermediateResults<T>
    {
        private readonly IDictionary<string, List<T>> _results = new Dictionary<string, List<T>>();

        public void Add(String key, T value)
        {
            if (_results.ContainsKey(key))
            {
                _results[key].Add(value);
            }
            else
            {
                _results.Add(key, new List<T> {value});
            }
        }

        public void Reduce(MapReduceJob<T> job, IMapperReducer<T> mapperReducer)
        {
            foreach (KeyValuePair<String, List<T>> mapResult in _results)
            {
                mapperReducer.Reduce(job, mapResult.Key, mapResult.Value);
            }
        }
    }
}