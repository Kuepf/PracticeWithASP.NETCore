using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersApp.Filters
{
    public class SimpleResourceFilter : Attribute, IResourceFilter
    {
        int _age;
        string _message;
        public SimpleResourceFilter(int age, string messeage)
        {
            _age = age;
            _message = messeage;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Age", _age.ToString());
            context.HttpContext.Response.Headers.Add("Message", _message);
        }
    }
}
