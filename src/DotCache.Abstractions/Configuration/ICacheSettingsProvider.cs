namespace DotCache.Abstractions.Configuration;

public interface ICacheSettingsProvider
{
    CacheSettings GetSettings();
}