using DotCache.Abstractions.Caching;
using DotCache.Abstractions.Storage;

namespace DotCache.Storage;

public class DefaultCacheStore : ICacheStore
{
    private readonly Dictionary<string, CacheItem> _items = new();

    public CacheItem? Get(string key)
    {
        return _items.TryGetValue(key, out var cacheItem) 
            ? cacheItem : default;
    }

    public void Put(string key, CacheItem value)
    {
        _items[key] = value;
    }

    public void Delete(string key)
    {
        if (_items.TryGetValue(key, out _))
        {
            _items.Remove(key);
        }
    }

    public void Flush()
    {
        _items.Clear();
    }

    public IEnumerable<(string Key, CacheItem CacheItem)> Items
    {
        get
        {
            foreach (var (key, value) in _items)
            {
                yield return (key, value);
            }
        }
    }
}