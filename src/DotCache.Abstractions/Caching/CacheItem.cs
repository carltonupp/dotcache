using DotCache.Abstractions.Common;

namespace DotCache.Abstractions.Caching;

public class CacheItem : IExpires
{
    public DateTime? ExpiryDate { get; set; }
    public object Value { get; set; }
}