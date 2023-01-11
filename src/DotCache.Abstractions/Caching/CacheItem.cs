using DotCache.Abstractions.Common;

namespace DotCache.Abstractions.Caching;

public class CacheItem : IExpires
{
    public string Key { get; init; }
    public DateTime? ExpiryDate { get; set; }
    public object Value { get; init; }
}