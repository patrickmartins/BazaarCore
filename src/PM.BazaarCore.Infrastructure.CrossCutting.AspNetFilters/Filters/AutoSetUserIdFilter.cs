using Microsoft.AspNetCore.Mvc.Filters;
using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Filters
{
    public class AutoSetUserIdFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.Any() || !context.HttpContext.User.Identity.IsAuthenticated)
                return;

            var models = context.ActionArguments.Values.ToList();

            models.ForEach(c => SetUserId(c, context.HttpContext.User.GetUserId()));
        }

        private void SetUserId(object model, Guid UserId)
        {
            var properties = model.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(UserIdAttribute)));

            foreach (var property in properties)
                property.SetValue(model, UserId);
        }
    }
}
