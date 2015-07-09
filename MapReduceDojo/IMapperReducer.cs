using System;
using System.Collections.Generic;

namespace MapReduceDojo
{
    public interface IMapperReducer<T>
    {
        void Map(IEmitter<T> emitter, String data);
        void Reduce(IEmitter<T> emitter, String key, List<T> values);
    }
}
