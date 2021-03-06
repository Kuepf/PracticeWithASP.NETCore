﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TryWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //using (var host = WebHost.Start("http://localhost:8080", context =>
            // context.Response.WriteAsync("Hello WebHost!")))
            //{
            //    Console.WriteLine("Application has been started");
            //    host.WaitForShutdown();
            //}
            //
            BuildWebHost(args).Run();
            //
            //
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
