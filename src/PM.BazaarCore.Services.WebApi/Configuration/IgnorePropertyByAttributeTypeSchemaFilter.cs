using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace PM.BazaarCore.Services.WebApi.Configuration
{
    public class IgnorePropertyByAttributeTypeSchemaFilter : ISchemaFilter
    {
        private readonly Type _typeAttribute;

        public IgnorePropertyByAttributeTypeSchemaFilter(Type typeAttribute)
        {
            _typeAttribute = typeAttribute;
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
                return;

            var properties = context.Type.GetProperties().Where(c => c.IsDefined(_typeAttribute)).ToList();

            if (!properties.Any())
                return;

            foreach (var property in properties)
            {
                var schemaProperty = schema.Properties.Keys.FirstOrDefault(c => c.ToLower().Equals(property.Name.ToLower()));

                if (schemaProperty != null)
                    schema.Properties.Remove(schemaProperty);
            }
        }
    }
}
