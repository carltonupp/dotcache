using DotCache.Abstractions.Storage;

namespace DotCache.Storage;

public class DefaultCacheStore : ICacheStore
{
    private readonly Dictionary<string, object> _items = new();

    public object? Get(string key)
    {
        return _items.TryGetValue(key, out var value) switch
        {
            true => value,
            _ => default
        };
    }

    public void Put(string key, object value)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(key);
        ArgumentNullException.ThrowIfNull(value);
        _items[key] = value;
    }

    public void Delete(string key)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(key);
        _items.Remove(key);
    }

    public void Flush()
    {
        _items.Clear();
    }
}