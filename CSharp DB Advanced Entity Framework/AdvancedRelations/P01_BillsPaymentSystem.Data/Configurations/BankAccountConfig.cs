using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Configurations
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(e => e.BankAccountId);

            builder.Property(e => e.BankName)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.SwiftCode)
                   .IsRequired(true)
                   .IsUnicode(false)
                   .HasMaxLength(20);

            builder.HasOne(e => e.PaymentMethod)
                   .WithOne(e => e.BankAccount)
                   .HasForeignKey<PaymentMethod>(e => e.BankAccountId);
        }
    }
}
