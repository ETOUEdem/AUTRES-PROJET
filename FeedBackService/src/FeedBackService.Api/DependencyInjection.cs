using FeedBackService.Core.Interfaces.Repositories;
using FeedBackService.Core.Interfaces.Services;
using FeedBackService.Core.Services;
using FeedBackService.Infrastructure.Context;
using FeedBackService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackService.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            //Ajoute de base tampons
            services.AddDbContext<FeedbackDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
            return services;
        }
    }
}
