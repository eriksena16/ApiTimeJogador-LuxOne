namespace LuxOne.Infrastructure.ConfigurationContract
{
    public interface IConfigurationServiceProvider
    {
        T Get<T>(string key);
    }
}
