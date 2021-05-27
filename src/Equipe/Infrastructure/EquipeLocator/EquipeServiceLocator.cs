using LuxOne.Contrato.EquipeContrato;
using LuxOne.Service.EquipeService;
using Microsoft.Extensions.DependencyInjection;

namespace LuxOne.Infrastructure.EquipeLocator
{
    public static class EquipeServiceLocator
    {
        public static void ConfigureEquipeService(this IServiceCollection services)
        {
            services.AddScoped<ITimeService, TimesServices>();
            services.AddScoped<IJogadoresService, JogadoresServices>();

        }
    }
}
