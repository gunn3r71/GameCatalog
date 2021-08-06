using System;
using GameCatalog.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.API.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Game>(
                g =>
                {
                    g.HasKey(x => x.Id);
                    g.Property(x => x.Id).IsRequired();
                    g.Property(x => x.Title).IsRequired().HasMaxLength(40);
                    g.Property(x => x.Developer).IsRequired().HasMaxLength(100);
                    g.Property(x => x.Price).IsRequired().HasPrecision(6, 2);
                    g.Property(x => x.Status);
                }
            );
            base.OnModelCreating(model);
        }
    }
}