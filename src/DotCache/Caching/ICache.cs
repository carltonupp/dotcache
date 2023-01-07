namespace DotCache.Caching;

public interface ICache
{
    TValue? Get<TValue>(string key);
    void Put<TValue>(string key, TValue value);
    void Delete(string key);
    void Flush();
}