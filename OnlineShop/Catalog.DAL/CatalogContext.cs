using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL;

internal class CatalogContext : DbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    
    public DbSet<ProductEntity> Products { get; set; }
    
    public CatalogContext(DbContextOptions options): base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>()
            .ToTable(nameof(CategoryEntity).ToLower())
            .HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<CategoryEntity>()
            .HasOne(x => x.ParentCategory);

        modelBuilder.Entity<CategoryEntity>()
            .HasIndex(x => x.Name)
            .IsUnique();
        
        modelBuilder.Entity<ProductEntity>()
            .ToTable(nameof(ProductEntity).ToLower());
    }
}