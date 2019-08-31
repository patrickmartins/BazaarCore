using Microsoft.Extensions.DependencyInjection;
using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
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
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "BazaarCore API",
                    Description = "API do site BazaarCore",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Patrick Souza Martins", Email = "patrick.sm@hotmail.com", Url = "https://www.linkedin.com/in/patrick-martins-93a823137/" }
                });

                options.AddSecurityDefinition("JwtToken", new ApiKeyScheme()
                {
                    Description = "Token de acesso a API",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
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
