using LuxOne.Contrato.EquipeContrato;
using LuxOne.Service.EquipeService;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LuxOne.Infrastructure.EquipeLocator
//namespace Microsoft.Extensions.DependencyInjection
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
