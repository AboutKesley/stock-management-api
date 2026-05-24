using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Domain.Interfaces;
using Stock.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Stock.Infrastructure.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StockDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        { 
            service.AddDbContext<StockDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            service.AddScoped<IItemRepository, ItemRepository>();

            return service;
        }
    }
}
