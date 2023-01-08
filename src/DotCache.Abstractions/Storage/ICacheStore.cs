namespace DotCache.Abstractions.Storage;

public interface ICacheStore
{
    object? Get(string key);
    void Put(string key, object value);
    void Delete(string key);
    void Flush();
}