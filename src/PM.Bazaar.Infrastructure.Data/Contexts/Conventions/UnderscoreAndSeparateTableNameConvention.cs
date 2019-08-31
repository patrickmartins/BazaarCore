using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PM.BazaarCore.Infrastructure.Data.Interfaces;
using System.Text.RegularExpressions;

namespace PM.BazaarCore.Infrastructure.Data.Contexts.Conventions
{
    public class UnderscoreAndSeparateTableNameConvention : IModelConvention
    {
        public void Apply(IMutableEntityType entity)
        {
            entity.Relational().TableName = Regex.Replace(entity.Relational().TableName, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]).ToLower();
        }
    }
}
