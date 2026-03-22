using Stock.Examples.DifferentNamespaceFromFolder;

namespace Stock.Examples
{
    public static class ExampleServiceCollectionExtensions
    {
        // Example of an extension method to add services to the DI container.
        public static IServiceCollection AddExamples(this IServiceCollection services)
        {
            services.AddTransient<ExampleLifeCycleService>();

            services.AddSingleton<ExampleSingleton>();
            services.AddScoped<ExampleScoped>();
            services.AddTransient<ExampleTransient>();

            services.AddSingleton<ExampleDifferentNamespaceFromFolder>();

            return services;
        }
    }
}