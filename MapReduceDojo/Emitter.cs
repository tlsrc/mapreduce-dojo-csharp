using System;

namespace MapReduceDojo
{
    public interface IEmitter<in T>
    {
        void Emit(String key, T value);
    }
}
