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
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Game>(
                g =>
                {
                    g.HasKey(x => x.Id);
                    g.Property(x => x.Id).IsRequired();
                    g.Property(x => x.Title).IsRequired().HasMaxLength(40);
                    g.Property(x => x.Price).IsRequired().HasPrecision(6, 2);
                    g.Property(x => x.Status);
                    g.HasOne(x => x.Category)
                        .WithMany(x => x.Games)
                        .HasForeignKey(x => x.CategoryId);
                    g.HasOne(x => x.Developer)
                        .WithMany(x => x.Games)
                        .HasForeignKey(x => x.DeveloperId);
                }
            );

            model.Entity<Developer>(
                d =>
                {
                    d.HasKey(x => x.Id);
                    d.Property(x => x.Id).IsRequired();
                    d.Property(x => x.Name).IsRequired().HasMaxLength(100);
                    d.Property(x => x.Status);
                }
            );

            model.Entity<Category>(
                c =>
                {
                    c.HasKey(x => x.Id);
                    c.Property(x => x.Id).IsRequired();
                    c.Property(x => x.Name).IsRequired().HasMaxLength(30);
                    c.Property(x => x.Status);
                }
            );
            base.OnModelCreating(model);
        }
    }
}