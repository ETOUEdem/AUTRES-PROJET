
using FeedBackService.Core.Interfaces.Repositories;
using FeedBackService.Core.Interfaces.Services;
using FeedBackService.Core.Services;
using FeedBackService.Infrastructure.Context;
using FeedBackService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackService.Api
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
            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "FeedbackService", Version = "v1" });
            // });
            //configure AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //services.AddScoped<IFeedbackService, FeedbackService>();
            //services.AddScoped<IFeedbackRepository,FeedbackRepository>();
            //Ajoute de base tampons
            // services.AddDbContext<FeedbackDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
            //depedency injection
            services.ConfigureDependencyInjection(Configuration);
            services.ConfigureCors();
            //configure Swapper
            services.ConfigureSwagger();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //  app.UseHttpCodeAndLogMiddleware();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FeedbackService v1"));
            }
            else
            {
                // app.UseHttpCodeAndLogMiddleware();
                app.UseHsts();
            }

            app.ConfigureSwagger();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
