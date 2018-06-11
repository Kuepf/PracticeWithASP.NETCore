using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersApp.Filters
{
    public class SimpleActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //None!
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("LestVisit", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));
        }
    }
}
