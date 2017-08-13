using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using USTVA.Entities;
using USTVA.Middleware.UrlRewriting;
using USTVA.Services;
using USTVA.ViewModels;

namespace USTVA
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public IConfigurationRoot Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<AdminAlert>();

            services.AddLogging();
            services.AddMvc().AddJsonOptions(config =>
            {
                config.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddSingleton(Configuration);

            services.AddSingleton<IGreeter, Greeter>();

            services.AddScoped<IIncidentData, SqlIncidentData>();

            services.AddEntityFrameworkSqlServer();

            Mapper.Initialize(config =>
                config.CreateMap<Incident, IncidentLocationViewModel>().ReverseMap());


            services.AddDbContext<IncidentDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MainPCDB")));

        }


        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IGreeter greeter,
            ILoggerFactory loggerFactory)
        {

            loggerFactory.AddFile($"Logs/bportfolio-{DateTime.Now.Date.ToString("MM-dd-yyyy")}.txt", LogLevel.Error);
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseRewriter(new RewriteOptions()
                    .Add(new RedirectWwwRule())
                    .AddRedirectToHttps()
                    .AddRedirect(@"^section1/(.*)", "new/$1", (int) HttpStatusCode.Redirect)
                    .AddRedirect(@"^section/(\\d+)/(.*)", "new/$1/$2", (int) HttpStatusCode.MovedPermanently)
                    .AddRewrite("^feed$", "/?format=rss", skipRemainingRules: false));

                
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseFileServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
