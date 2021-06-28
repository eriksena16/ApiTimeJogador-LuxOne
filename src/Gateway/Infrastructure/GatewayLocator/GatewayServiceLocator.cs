using LuxOne.Contract.GatewayContract;
using LuxOne.Service.GatewayService;
using Microsoft.Extensions.DependencyInjection;

namespace LuxOne.Infrastructure.GatewayLocator
{
    public static class GatewayServiceLocator
    {
        public static void ConfigureGatewayService(this IServiceCollection services)
        {
            services.AddScoped<IGatewayServiceProvider, GatewayServiceProvider>();
        }
    }
}
