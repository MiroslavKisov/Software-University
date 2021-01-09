namespace CarDealer.Data
{
    using CarDealer.Data.Configurations;
    using CarDealer.Models;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using System;
    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions options) 
            : base(options)
        {

        }

        public CarDealerContext()
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> CarParts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new PartConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new PartCarConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
        }
    }
}
