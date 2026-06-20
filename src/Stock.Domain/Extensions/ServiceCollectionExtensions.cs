using Microsoft.Extensions.DependencyInjection;
using Stock.Domain.Interfaces;
using Stock.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();

            return services; 
        }
    }
}
