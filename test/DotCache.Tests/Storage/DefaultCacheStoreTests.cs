using DotCache.Storage;

namespace DotCache.Tests.Storage;

public class DefaultCacheStoreTests : IClassFixture<DefaultCacheStore>
{
    private readonly DefaultCacheStore _fixture;

    public DefaultCacheStoreTests(DefaultCacheStore store)
    {
        _fixture = store;
    }

    [Fact]
    public void CanCreateDefaultCacheStore()
    {
        var store = new DefaultCacheStore();
        Assert.IsType<DefaultCacheStore>(store);
    }

    [Fact]
    public void CanAddItemToCacheStore()
    {
        _fixture.Put("number_of_days", 7);
        Assert.Equal(7, _fixture.Get("number_of_days"));
    }

    [Fact]
    public void CanNotAddItemToCacheStoreWithInvalidKey()
    {
        var store = new DefaultCacheStore();
        Assert.Throws<ArgumentNullException>(() =>
        {
            store.Put(null, 7);
        });
    }
    
    [Fact]
    public void CanNotAddItemToCacheStoreWithInvalidValue()
    {
        var store = new DefaultCacheStore();
        Assert.Throws<ArgumentNullException>(() =>
        {
            store.Put("number_of_days", null);
        });
    }

    [Fact]
    public void CanDeleteFromCacheStore()
    {
        var store = new DefaultCacheStore();
        store.Put("number_of_days", 7);
        store.Delete("number_of_days");
        Assert.Null(store.Get("number_of_days"));
    }

    [Fact]
    public void CanNotDeleteFromCacheStoreWithInvalidKey()
    {
        var store = new DefaultCacheStore();
        Assert.Throws<ArgumentNullException>(() =>
        {
            store.Delete(null);
        });
    }
}