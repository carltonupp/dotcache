using DotCache.Abstractions.Caching;
using DotCache.Abstractions.Configuration;
using DotCache.Abstractions.Storage;

namespace DotCache.Caching;

public class Cache : ICache
{
    private readonly ICacheStore _store;
    private readonly ICacheSettingsProvider _settingsProvider;

    public Cache(ICacheStore store, ICacheSettingsProvider settingsProvider)
    {
        _store = store;
        _settingsProvider = settingsProvider;
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

    public CacheItem? GetCacheItem(string key)
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

        var settings = _settingsProvider.GetSettings();

        var cacheItem = new CacheItem
        {
            Value = value,
            ExpiryDate = DateTime.Now.AddSeconds(settings.TimeToLive)
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