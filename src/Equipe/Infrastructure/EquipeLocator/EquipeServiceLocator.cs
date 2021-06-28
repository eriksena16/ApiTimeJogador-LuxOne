using LuxOne.Contract.EquipeContrato;
using LuxOne.Service.EquipeService;
using Microsoft.Extensions.DependencyInjection;

namespace LuxOne.Infrastructure.EquipeLocator
{
    public static class EquipeServiceLocator
    {
        public static void ConfigureEquipeService(this IServiceCollection services)
        {
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IJogadorService, JogadorService>();

        }
    }
}
