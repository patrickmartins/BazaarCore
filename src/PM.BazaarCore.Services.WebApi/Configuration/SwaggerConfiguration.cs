using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;

namespace PM.BazaarCore.Services.WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BazaarCore API",
                    Description = "API do site BazaarCore",
                    Contact = new OpenApiContact { Name = "Patrick Souza Martins", Email = "patrick.sm@hotmail.com", Url = new Uri("https://www.linkedin.com/in/patrick-martins-93a823137/") }
                });

                options.AddSecurityDefinition("JwtToken", new OpenApiSecurityScheme()
                {
                    Description = "Token de acesso a API",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);

                options.OperationFilter<SecurityRequirementsOperationFilter>(true, "JwtToken");
                options.SchemaFilter<IgnorePropertyByAttributeTypeSchemaFilter>(typeof(SwaggerIgnoreAttribute));
            });
        }
    }
}
