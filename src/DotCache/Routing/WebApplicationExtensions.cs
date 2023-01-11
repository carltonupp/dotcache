using DotCache.Abstractions.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace DotCache.Routing;

public static class WebApplicationExtensions
{
    public static void AddCachingRoutes(this WebApplication app)
    {
        app.MapGet("/{key}", 
            ([FromServices] ICache cache, string key) => cache.Get(key));

        app.MapPost("/{key}",
            ([FromServices] ICache cache, string key, NewCacheItem item) => cache.Put(key, item.Value));

        app.MapDelete("/{key}", 
            ([FromServices] ICache cache, string key) => cache.Delete(key));
    }
}