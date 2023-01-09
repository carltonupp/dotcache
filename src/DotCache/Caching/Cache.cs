using DotCache.Abstractions.Caching;
using DotCache.Abstractions.Storage;

namespace DotCache.Caching;

public class Cache : ICache
{
    private readonly ICacheStore _store;

    public Cache(ICacheStore store)
    {
        _store = store;
    }

    public object? Get(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Parameter '{Parameter}' cannot be null or empty.", nameof(key));
        }

        var cacheItem = _store.Get(key);
        return cacheItem?.Value;
    }

    public void Put(string key, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Parameter '{Parameter}' cannot be null or empty.", nameof(key));
        }

        var cacheItem = new CacheItem
        {
            Value = value
        };

        _store.Put(key, cacheItem);
    }

    public void Delete(string key)
    {
        _store.Delete(key);
    }

    public void Flush()
    {
        _store.Flush();
    }
}