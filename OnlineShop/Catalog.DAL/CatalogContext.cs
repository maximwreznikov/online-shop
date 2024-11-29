using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL;

internal class CatalogContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>()
            .ToTable("categories")
            .HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CategoryEntity>()
            .HasIndex(x => x.Name)
            .IsUnique();

        modelBuilder.Entity<ProductEntity>()
            .ToTable("products");
    }
}
