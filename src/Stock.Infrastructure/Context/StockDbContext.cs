using Microsoft.EntityFrameworkCore;
using Stock.Domain.Models;

namespace Stock.Infrastructure.Context;

public class StockDbContext : DbContext
{
    public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>();
    }
}