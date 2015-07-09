using System;
using System.Collections.Generic;

namespace MapReduceDojo
{
    public interface IDataSource
    {
        IEnumerator<String> GetEnumerator();
        int Size();
    }
}
