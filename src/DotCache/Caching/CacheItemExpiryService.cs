using System.Collections.Immutable;
using DotCache.Abstractions.Caching;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotCache.Caching;

public class CacheItemExpiryService : IHostedService
{
    private readonly ICache _cache;
    private readonly ILogger<CacheItemExpiryService> _logger;
    private DateTime NextCheck = DateTime.Now;

    public CacheItemExpiryService(ICache cache, 
        ILogger<CacheItemExpiryService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            if (NextCheck >= DateTime.Now)
                continue;

            RemoveExpiredCacheItems();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    private void RemoveExpiredCacheItems()
    {
        var items = _cache.ExpiredItems.ToImmutableArray();
        if (items.Any())
        {
            _logger.LogInformation("Removing {Count} expired items from cache", 
                items.Length);
            
            foreach (var item in _cache.ExpiredItems)
            {
                _cache.Delete(item.Key);
            }
            
            _logger.LogInformation("Removed {Count} expired items from cache", 
                items.Length);
        }
        
        NextCheck = DateTime.Now.AddSeconds(60);
    }
}