using System;
using System.Collections.Generic;
using MapReduceDojo.results;

namespace MapReduceDojo
{
    public class MapReduceJob<T> : IEmitter<T>
    {
        private enum Phase {Map, Reduce}

        private Phase _phase;
        private readonly IMapperReducer<T> _mapperReducer;

        private readonly FinalResults<T> _finalResults;
        private readonly IntermediateResults<T> _intermediateResults;

        public MapReduceJob(IMapperReducer<T> mapperReducer)
        {
            _finalResults = new FinalResults<T>();
            _intermediateResults = new IntermediateResults<T>();
            _mapperReducer = mapperReducer;
        }

        public void Run(IDataSource dataSource)
        {
            Map(dataSource);
            Reduce();
            Print();
        }

        private void Map(IDataSource dataSource)
        {
            _phase = Phase.Map;

            IEnumerator<String> enumerator = dataSource.GetEnumerator();
            while(enumerator.MoveNext())
            {
                _mapperReducer.Map(this, enumerator.Current);
            }
        }

        private void Reduce()
        {
            _phase = Phase.Reduce;
            _intermediateResults.Reduce(this, _mapperReducer);
        }

        public void Emit(String key, T value)
        {
            switch (_phase)
            {
                case Phase.Map : _intermediateResults.Add(key, value); return;
                case Phase.Reduce: _finalResults.Add(key, value); return;
            }
        }

        public T GetFinalResults(String key)
        {
            return _finalResults.GetResultsFor(key);
        }

        private void Print()
        {
            Console.WriteLine(_finalResults);
        }
    }
}
