using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PM.BazaarCore.Infrastructure.Data.Interfaces;
using System.Text.RegularExpressions;

namespace PM.BazaarCore.Infrastructure.Data.Contexts.Conventions
{
    public class UnderscoreAndSeparatePropertyNameConvention : IModelConvention
    {
        public void Apply(IMutableEntityType entity)
        {
            var properties = entity.GetProperties();

            foreach(var property in properties)
                property.Relational().ColumnName = Regex.Replace(property.Relational().ColumnName, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]).ToLower();
        }
    }
}
