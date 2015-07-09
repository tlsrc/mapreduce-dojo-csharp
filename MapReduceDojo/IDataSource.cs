using System.Collections;

namespace MapReduceDojo
{
    public interface IDataSource
    {
        IEnumerator GetIterator();
        int Size();
    }
}
