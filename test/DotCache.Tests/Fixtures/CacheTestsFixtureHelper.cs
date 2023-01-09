using DotCache.Abstractions.Configuration;
using DotCache.Caching;
using DotCache.Storage;
using Moq;

namespace DotCache.Tests.Fixtures;

public class CacheTestsFixtureHelper
{
    public static Cache Fixture
    {
        get
        {
            var store = new DefaultCacheStore();
            var settingsProvider = new Mock<ICacheSettingsProvider>();
            settingsProvider.Setup(sp => sp.GetSettings()).Returns(new CacheSettings
            {
                SecondsUntilExpiry = 300
            });
            return new Cache(store, settingsProvider.Object);
        }
    }  
}