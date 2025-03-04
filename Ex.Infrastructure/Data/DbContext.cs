using Ex.Domain.Entities;  // Correct namespace for Product class
using Microsoft.EntityFrameworkCore;

namespace Ex.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

         // Using ModelBuilder to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id); // Defining primary key

                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(p => p.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
    }
}
}
