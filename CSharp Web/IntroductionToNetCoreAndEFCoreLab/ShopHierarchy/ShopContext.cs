using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHierarchy
{
    public class ShopContext : DbContext
    {
        private const string connectionString = @"server=.;Database=ShopHierarchyDb;integrated security=true";

        public ShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public ShopContext()
        {
        }

        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ItemOrder> ItemsOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salesman>()
                .HasMany(e => e.Customers)
                .WithOne(e => e.Salesman)
                .HasForeignKey(e => e.SalesmanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Reviews)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Reviews)
                .WithOne(e => e.Item)
                .HasForeignKey(e => e.ItemId);

            modelBuilder.Entity<ItemOrder>()
                .HasKey(e => new { e.ItemId, e.OrderId });

            modelBuilder.Entity<ItemOrder>()
                .HasOne(e => e.Order)
                .WithMany(e => e.ItemsOrders)
                .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<ItemOrder>()
                .HasOne(e => e.Item)
                .WithMany(e => e.ItemsOrders)
                .HasForeignKey(e => e.ItemId);
        }
    }
}
