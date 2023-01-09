using System.Collections;
using DotCache.Abstractions.Caching;
using DotCache.Abstractions.Storage;

namespace DotCache.Storage;

public class DefaultCacheStore : ICacheStore
{
    private readonly Hashtable _items = new();

    public CacheItem? Get(string key)
    {
        if (_items[key] is CacheItem cacheItem)
        {
            return cacheItem;
        }

        return default;
    }

    public void Put(string key, CacheItem value)
    {
        _items[key] = value;
    }

    public void Delete(string key)
    {
        _items.Remove(key);
    }

    public void Flush()
    {
        _items.Clear();
    }
}