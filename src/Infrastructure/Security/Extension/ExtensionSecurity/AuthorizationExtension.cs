using Microsoft.Extensions.DependencyInjection;

namespace LuxOne.Infrastructure.Security.Extension.ExtensionSecurity
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
        {
           return services.AddAuthorization(options =>
            {
                options.AddPolicy("TimeCadastro", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole("Manager");
                    builder.RequireClaim("Time", "Cadastro");
                });

            });
        }
    }
}
