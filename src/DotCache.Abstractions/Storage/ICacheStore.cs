using DotCache.Abstractions.Caching;

namespace DotCache.Abstractions.Storage;

public interface ICacheStore
{
    CacheItem? Get(string key);
    void Put(string key, CacheItem value);
    void Delete(string key);
    void Flush();
    IEnumerable<CacheItem> Items { get; }
}