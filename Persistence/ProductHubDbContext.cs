using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{

    public class ProductHubDbContext : DbContext
    {
        public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options)
            : base(options)
        {
        }

        // DbSet for User entity
        public DbSet<User> Users { get; set; }

        // DbSet for Product entity
        public DbSet<Product> Products { get; set; }

        // DbSet for Category entity
        public DbSet<Category> Categories { get; set; }

        // DbSet for the join table ProductCategory (for many-to-many relationship)
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Product and Category
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
