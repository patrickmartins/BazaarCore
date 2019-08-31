using Microsoft.AspNetCore.Mvc.ModelBinding;
using PM.BazaarCore.Domain.Core.Values;
using System.Linq;

namespace PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Extensions
{
    public static class ModelStateExtensions
    {
        public static OperationResult ToOperationResult(this ModelStateDictionary dictionary)
        {
            var result = new OperationResult();

            foreach (var state in dictionary)
                if (state.Value.Errors.Count > 0)
                    foreach (var error in state.Value.Errors)
                        result.AddError(state.Key.Split('.').Last(), error.ErrorMessage);
            
            return result;
        }
    }
}