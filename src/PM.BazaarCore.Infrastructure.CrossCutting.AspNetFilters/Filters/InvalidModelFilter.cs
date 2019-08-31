using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Extensions;

namespace PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Filters
{
    public class InvalidModelFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState.ToOperationResult().Errors);
            }
        }
    }
}
