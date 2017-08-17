using System.Collections.Generic;

namespace USTVA.Services
{
    public interface ILocalDataProvider<T>
    {
        IEnumerable<T> Get(string key);
    }
}
