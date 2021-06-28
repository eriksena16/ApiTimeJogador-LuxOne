using LuxOne.Infrastructure.ConfigurationContract;
using LuxOne.Infrastructure.ConfigurationService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureServiceLocator
    {
        public static IServiceCollection AddInfrastructureServiceLocator(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationServiceProvider, ConfigurationServiceProvider>();
            return services;
        }
    }
}
