using Microsoft.EntityFrameworkCore;
using Stock.Domain.Models;
using Stock.Infrastructure.Configurations;

namespace Stock.Infrastructure.Context;

public sealed class StockDbContext : DbContext
{
    public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }
}