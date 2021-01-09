using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Configuration;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(ConnectionConfiguration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.Property(e => e.Date)
                    .IsRequired(true)
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.ProductId);

                entity.HasOne(e => e.Customer)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.CustomerId);

                entity.HasOne(e => e.Store)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.StoreId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                
                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(100);
                
                entity.Property(e => e.Email)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(80);
                
                entity.Property(e => e.CreditCardNumber)
                .IsRequired(true)
                .IsUnicode(false);

                entity.HasMany(e => e.Sales)
                    .WithOne(e => e.Customer)
                    .HasForeignKey(e => e.CustomerId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity.Property(e => e.Quantity)
                    .IsRequired(true)
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Description)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasDefaultValue("No description");

                entity.Property(e => e.Price)
                    .IsRequired(true);

                entity.HasMany(e => e.Sales)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(80);

                entity.HasMany(e => e.Sales)
                .WithOne(e => e.Store)
                .HasForeignKey(e => e.StoreId);
            });
        }
    }
}
