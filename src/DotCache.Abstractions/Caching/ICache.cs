namespace DotCache.Abstractions.Caching;

public interface ICache
{
    object? Get(string key);
    CacheItem? GetCacheItem(string key);
    IEnumerable<CacheItem> ExpiredItems { get; }
    void Put(string key, object value);
    void Delete(string key);
    void Flush();
}