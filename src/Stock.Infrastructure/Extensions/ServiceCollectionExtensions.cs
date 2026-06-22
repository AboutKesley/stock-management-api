using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Interfaces;
using Stock.Infrastructure.Context;
using Stock.Infrastructure.Database;

namespace Stock.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<StockDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}