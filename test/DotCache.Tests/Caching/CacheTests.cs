using DotCache.Caching;

namespace DotCache.Tests.Caching;

public class CacheTests : IClassFixture<Cache>
{
    private readonly Cache _fixture;

    public CacheTests(Cache fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CanAddItemToCacheAndRetrieve()
    {
        _fixture.Put("number-of-days", 7);
        var numberOfDays = _fixture.Get<int>("number-of-days");
        Assert.Equal(7, numberOfDays);
    }

    [Fact]
    public void GetWithEmptyKeyThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _fixture.Get<int>("");
        });
    }
}