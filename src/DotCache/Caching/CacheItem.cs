namespace DotCache.Caching;

public class CacheItem
{
    public required object? Value { get; init; }
    public DateTime Expires { get; set; }
}