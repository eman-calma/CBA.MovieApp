using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBA.MovieApp.Infrastructure.Cache
{
    public interface ICacheData<T>
    {
        public Task<T> GetOrCreate(object key, Func<Task<T>> createItem);
    }
}
