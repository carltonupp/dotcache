namespace DotCache.Abstractions.Caching;

public interface ICache
{
    object? Get(string key);
    void Put(string key, object value);
    void Delete(string key);
    void Flush();
}