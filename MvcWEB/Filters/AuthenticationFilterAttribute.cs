using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWEB.Filters
{
    public class AuthenticationFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var res = context.HttpContext.Request.Cookies["SignedUser"];

            if (string.IsNullOrEmpty(res))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Register", action = "SignIn"}));
            }
        }
    }
}
