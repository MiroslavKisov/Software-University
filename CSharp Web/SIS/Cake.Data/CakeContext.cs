namespace Cake.Data
{
    using Configurations;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class CakeContext : DbContext
    {
        public CakeContext(DbContextOptions options) 
            : base(options)
        {
        }

        public CakeContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.connectionString).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
