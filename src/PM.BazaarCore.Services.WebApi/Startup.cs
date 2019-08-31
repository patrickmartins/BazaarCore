using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Filters;
using PM.BazaarCore.Services.WebApi.Configuration;
using System.Reflection;

namespace PM.BazaarCore.Services.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBazaarServices(Configuration);
            services.ConfigureJwt(Configuration);
            services.AddAutoMapper(Assembly.GetEntryAssembly());

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);                
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(c => c.SuppressModelStateInvalidFilter = true);
            
            services.AddMvc(c => 
            {
                c.Filters.Add(new InvalidModelFilter());
                c.Filters.Add(new AutoSetUserIdFilter());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.DocumentTitle = "BazaarCore API";
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "BazaarCore API V1.0");                
            });

            app.UseMvc();
        }
    }
}
