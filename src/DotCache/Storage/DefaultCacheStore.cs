using DotCache.Abstractions.Storage;

namespace DotCache.Storage;

public class DefaultCacheStore : ICacheStore
{
    private readonly Dictionary<string, object> _items = new();

    public object? Get(string key)
    {
        var item = _items.TryGetValue(key, out var value);
        return value;
    }

    public void Put(string key, object value)
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