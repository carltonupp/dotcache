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

    [Fact]
    public void PutWithEmptyKeyThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _fixture.Put("", 8);
        });
    }

    [Fact]
    public void PutWithNullValueThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _fixture.Put<object>("last_tested_date", null);
        });
    }

    [Fact]
    public void CanDeleteCacheItem()
    {
        _fixture.Put("number_of_days", 7);
        _fixture.Delete("number_of_days");
        var value = _fixture.Get<int>("number_of_days");
        Assert.Equal(0, value);
    }

    [Fact]
    public void CanFlushCache()
    {
        _fixture.Put("day_1", "monday");
        _fixture.Put("day_2", "tuesday");
        _fixture.Put("day_3", "wednesday");
        _fixture.Put("day_4", "thursday");
        _fixture.Put("day_5", "friday");
        _fixture.Put("day_6", "saturday");
        _fixture.Put("day_7", "sunday");
        
        _fixture.Flush();

        var day1ShouldBeNull = _fixture.Get<string>("day_1");
        Assert.Null(day1ShouldBeNull);
    }
}