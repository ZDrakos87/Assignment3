using Microsoft.EntityFrameworkCore;

namespace Assignment4.Models
{
    
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Cliff Bar Crunchy Peanut Butter", Price = 1.50m, Quantity = 10, Weight = 2.4m },
                new Product { ProductId = 2, Name = "Doritos Nacho Cheese", Price = 2.29m, Quantity = 12, Weight = 2.7m },
                new Product { ProductId = 3, Name = "Lay's Classic Potato Chips", Price = 2.29m, Quantity = 15, Weight = 2.88m },
                new Product { ProductId = 4, Name = "M&M's Milk Chocolate", Price = 1.69m, Quantity = 20, Weight = 1.69m },
                new Product { ProductId = 5, Name = "Milky Way Chocolate", Price = 1.35m, Quantity = 18, Weight = 1.76m },
                new Product { ProductId = 6, Name = "Nature Valley Crunchy Oats", Price = 1.46m, Quantity = 14, Weight = 1.49m }
            );
        }
    }
}
