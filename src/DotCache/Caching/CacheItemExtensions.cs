using DotCache.Abstractions.Caching;

namespace DotCache.Caching;

public static class CacheItemExtensions
{
    public static bool IsExpired(this CacheItem cacheItem)
    {
        if (cacheItem.ExpiryDate is null) return false;
        if (cacheItem.ExpiryDate == DateTime.MinValue) return false;
        return cacheItem.ExpiryDate <= DateTime.Now;
    }
}