using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBA.MovieApp.Infrastructure.Cache
{
    public class CacheData<T> : ICacheData<T>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public async Task<T> GetOrCreate(object key, Func<Task<T>> createItem)
        {
            T cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = await createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1)
                .SetPriority(CacheItemPriority.High)
                .SetSlidingExpiration(TimeSpan.FromDays(1))
                .SetAbsoluteExpiration(TimeSpan.FromDays(1));

                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
