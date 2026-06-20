using Microsoft.EntityFrameworkCore;
using Stock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Infrastructure.Database.Context
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}
