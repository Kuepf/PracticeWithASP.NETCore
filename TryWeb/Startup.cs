using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TryWeb.Services;
using System.IO;

namespace TryWeb
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            AppConfig = config;            
        }
        public IConfiguration AppConfig { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IServiceMessenger, ServiceMessenger>();
            //services.AddTransient<AnotherMessenger>();
            services.AddOptions();

            services.Configure<Person>(AppConfig);
            services.Configure<Person>(opt =>
            {
                opt.Age = 22;
            });
            services.Configure<Person>(AppConfig.GetSection("company"));
        }

        public void Configure(IApplicationBuilder app)
        {

            //string java_dir = AppConfig["JAVA_HOME"] ?? "not set";
            //int x = 5;
            //int y = 2;
            //int z = 0;
            //app.Use(async (context, next) =>
            //{
            //    z = x * y;//=10
            //    await next();
            //    z = z * 5;//100
            //    await context.Response.WriteAsync($"z = {z}");
            //});

            //IConfiguration connStrings = AppConfig.GetSection("ConnectionStrings");
            //string defaultConnection = connStrings.GetSection("DefaultConnection").Value;

            //var color = AppConfig["color"];
            //var text = AppConfig["text"];

            app.UseMiddleware<PersonMiddleware>();

            //app.Run(async (context) =>
            //{
            //    z = z * 2;//20
            //    await Task.FromResult(0);

            //});
        }
    }
}
