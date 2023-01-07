namespace DotCache.Caching;

public class Cache : ICache
{
    private readonly Dictionary<string, CacheItem> _cacheItems = new();

    public TValue? Get<TValue>(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Parameter '{Parameter}' cannot be null or empty.", nameof(key));
        }

        return _cacheItems.TryGetValue(key, out var item) switch
        {
            true when item?.Value is TValue val => val,
            _ => default
        };
    }

    public void Put<TValue>(string key, TValue value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Parameter '{Parameter}' cannot be null or empty.", nameof(key));
        }
        
        var item = new CacheItem
        {
            Value = value
        };
        
        _cacheItems.Add(key, item);
    }

    public void Delete(string key)
    {
        _cacheItems.Remove(key);
    }

    public void Flush()
    {
        _cacheItems.Clear();
    }
}