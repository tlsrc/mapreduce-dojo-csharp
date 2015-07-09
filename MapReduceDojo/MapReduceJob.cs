using System;
using System.Collections.Generic;

namespace MapReduceDojo
{
    public class MapReduceJob<T> : IEmitter<T> {

        private enum Phase {Map, Reduce}

        private Phase _phase;
        private readonly IMapperReducer<T> _mapperReducer;

        private readonly IDictionary<String, T> _finalResults = new Dictionary<String, T>();
        private readonly IDictionary<String, List<T>> _results = new Dictionary<String, List<T>>();

        public MapReduceJob(IMapperReducer<T> mapperReducer, IDataSource dataSource)
        {
            _mapperReducer = mapperReducer;
            Map(dataSource);
            Reduce();
            Print();
        }

        private void Map(IDataSource dataSource)
        {
            _phase = Phase.Map;

            IEnumerator<String> enumerator = dataSource.GetIterator();
            while(enumerator.MoveNext())
            {
                _mapperReducer.Map(this, enumerator.Current);
            }
        }

        private void Reduce()
        {
            _phase = Phase.Reduce;

            foreach (KeyValuePair<String, List<T>> mapResult in _results)
            {
                _mapperReducer.Reduce(this, mapResult.Key, mapResult.Value);
            }
        }

        public void Emit(String key, T value)
        {
            switch (_phase)
            {
                case Phase.Map : AddResult(key, value); return;
                case Phase.Reduce: _finalResults.Add(key, value); break;
            }
        }

        public IDictionary<String, T> GetResults()
        {
            return _finalResults;
        }

        private void AddResult(String key, T value)
        {
            List<T> values = _results[key] ?? new List<T>();
            values.Add(value);
            _results.Add(key, values);
        }

        private void Print()
        {
            Console.WriteLine(_finalResults);
        }
    }
}
