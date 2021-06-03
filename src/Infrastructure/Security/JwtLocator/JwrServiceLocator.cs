using LuxOne.Infrastructure.Contract.InfrastructureContract.Security;
using LuxOne.Infrastructure.Security.JwtAuthorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuxOne.Infrastructure.Security.JwtLocator
{
   public static class JwrServiceLocator
    {
        public static  void CofigureJwtService(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthotizationService, JwtAuthorizationService>();
        }
    }
}
