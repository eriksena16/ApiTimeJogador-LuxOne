using LuxOne.Infrastructure.EquipeLocator;
using LuxOne.Infrastructure.GatewayLocator;
using LuxOne.Infrastructure.Security.Extension.ExtensionSecurity;
using LuxOne.Infrastructure.Security.JwtLocator;
using LuxOne.Repository.EquipeRepositoryMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiTimeJogador_LuxOne
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureEquipeService();
            services.ConfigureGatewayService();
            services.CofigureJwtService();
            services.AddJwtAuthentication();
            services.AddDbContext<DbMemoryContext>(opt => opt.UseInMemoryDatabase("TimeJogador"));
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiTimeJogador_LuxOne", Version = "v1" });
            });
            /* services.PostConfigure<BearerSecurityKey>(options =>
             {
                 options.JwtSecurityKey = configuration[nameof(options.JwtSecurityKey)];
             });*/

            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTimeJogador_LuxOne v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
