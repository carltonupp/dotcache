using DotCache.Caching;
using DotCache.Storage;

namespace DotCache.Tests.Fixtures;

public class CacheTestsFixtureHelper
{
    public Cache Fixture
    {
        get
        {
            var store = new DefaultCacheStore();
            return new Cache(store);
        }
    }  
}