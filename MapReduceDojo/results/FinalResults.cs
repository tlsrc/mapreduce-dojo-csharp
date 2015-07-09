using System;
using System.Collections.Generic;
using System.Text;

namespace MapReduceDojo.results
{
    public class FinalResults<T>
    {
        private readonly IDictionary<string, T> _results = new Dictionary<string, T>();

        public void Add(String key, T value)
        {
            _results.Add(key, value);
        }

        public T GetResultsFor(string key)
        {
            return _results[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var result in _results)
            {
                sb.Append(result.Key).Append(":").Append(result.Value).AppendLine();
            }
            return sb.ToString();
        }
    }
}