namespace DotCache.Abstractions.Caching;

public interface ICache
{
    object? Get(string key);
    CacheItem? GetCacheItem(string key);
    IEnumerable<(string Key, CacheItem Item)> GetCacheItems();
    void Put(string key, object value);
    void Delete(string key);
    void Flush();
}