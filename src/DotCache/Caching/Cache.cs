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

        return _store.Get(key);
    }

    public void Put(string key, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Parameter '{Parameter}' cannot be null or empty.", nameof(key));
        }

        _store.Put(key, value);
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