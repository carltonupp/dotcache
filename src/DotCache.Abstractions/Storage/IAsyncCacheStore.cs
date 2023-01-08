namespace DotCache.Abstractions.Storage;

public interface IAsyncCacheStore
{
    Task<object> GetAsync(string key);
    Task PutAsync(string key, object value);
    Task DeleteAsync(string key);
    Task FlushAsync();
}