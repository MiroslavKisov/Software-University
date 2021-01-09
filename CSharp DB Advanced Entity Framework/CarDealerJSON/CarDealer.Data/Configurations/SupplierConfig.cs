using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Parts)
                   .WithOne(e => e.Supplier)
                   .HasForeignKey(e => e.SuplierId);
        }
    }
}
