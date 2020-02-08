using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HNChallenge.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HNChallenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddMvcOptions(opts =>
                {
                    opts.EnableEndpointRouting = false;
                });
            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });

            // Register services
            services.AddTransient<ItemsService>();
            services.AddTransient<UsersService>();
            services.AddTransient<ObjectMappingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.WebRootPath)
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors(opt => 
            opt.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
                .AllowAnyMethod());

        }
    }
}
