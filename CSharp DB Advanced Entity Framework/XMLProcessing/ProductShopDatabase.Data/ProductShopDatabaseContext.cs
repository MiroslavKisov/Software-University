namespace ProductShopDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductShopDatabase.Data.Configuration;
    using ProductShopDatabase.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductShopDatabaseContext : DbContext
    {
        public ProductShopDatabaseContext()
        {

        }

        public ProductShopDatabaseContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new CategoryProductsConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new CategoryConfig());
        }
    }
}
