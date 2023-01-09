namespace DotCache.Abstractions.Caching;

public static class CacheItemExtensions
{
    public static bool IsExpired(this CacheItem cacheItem)
    {
        if (cacheItem.ExpiryDate is null) return false;
        return cacheItem.ExpiryDate <= DateTime.Now;
    }
}