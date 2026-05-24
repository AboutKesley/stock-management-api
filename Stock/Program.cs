using Scalar.AspNetCore;
using Stock.Extensions;
using Stock.Examples;
using Stock.Domain.Extensions;
using Stock.Domain.Interfaces;
using Stock.Domain.Services;
using Stock.Infrastructure.Database;
using Stock.Infrastructure.Database.Extensions;
using Stock.Application.WebApi.Middleware;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddServices();
        builder.Services.AddExamples();
        builder.Services.AddDomain();
        //builder.Services.AddScoped<IItemService, ItemService>();
        //builder.Services.AddScoped<IItemRepository, ItemRepository>();
        //builder.Services.AddDbContext<StockDbContext>();
        builder.Services.AddInfrastructure(builder.Configuration);



        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/openapi/v1.json", "Stock API v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();
        app.Run();

    }
}