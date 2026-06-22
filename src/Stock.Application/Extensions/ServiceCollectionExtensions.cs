using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Interfaces;
using Stock.Application.Services;

namespace Stock.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();

        return services;
    }
}