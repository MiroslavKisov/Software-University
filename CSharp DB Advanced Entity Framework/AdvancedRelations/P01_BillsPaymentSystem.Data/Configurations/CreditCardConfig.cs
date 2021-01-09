using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Configurations
{
    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(e => e.CreditCardId);

            builder.Ignore("LimitLeft");

            builder.HasOne(e => e.PaymentMethod)
                   .WithOne(e => e.CreditCard)
                   .HasForeignKey<PaymentMethod>(e => e.CreditCardId);
        }
    }
}
