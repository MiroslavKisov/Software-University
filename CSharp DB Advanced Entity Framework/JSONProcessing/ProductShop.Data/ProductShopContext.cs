namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId});

                entity.HasOne(e => e.Category)
                      .WithMany(e => e.CategoryProducts)
                      .HasForeignKey(e => e.CategoryId);

                entity.HasOne(e => e.Product)
                      .WithMany(e => e.CategoryProducts)
                      .HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .IsRequired(false);

                entity.Property(e => e.LastName)
                      .IsRequired(true);

                entity.Property(e => e.Age)
                      .IsRequired(false);

                entity.HasMany(x => x.ProductsBought)
                      .WithOne(x => x.Buyer)
                      .HasForeignKey(x => x.BuyerId);

                entity.HasMany(x => x.ProductsSold)
                      .WithOne(x => x.Seller)
                      .HasForeignKey(x => x.SellerId);
            });
        }
    }
}
