﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingApp
{
    public class AdminRoute : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(RouteContext context)
        {
            string url = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (url.StartsWith("/Admin", StringComparison.OrdinalIgnoreCase))
            {
                context.Handler = async ctx =>
                {
                    ctx.Response.ContentType = "text/html; charset=utf-8";
                    await ctx.Response.WriteAsync("Привет Админ!");
                };
            }

            return Task.CompletedTask;
        }
    }
}
