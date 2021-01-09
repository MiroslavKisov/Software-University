namespace ProductShopDatabase.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShopDatabase.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                   .IsRequired(false)
                   .IsUnicode(false)
                   .HasMaxLength(50);

            builder.Property(e => e.LastName)
                   .IsRequired(true)
                   .IsUnicode(false);

            builder.Property(e => e.Age)
                   .IsRequired(false);

            builder.HasMany(e => e.ProductsSold)
                   .WithOne(e => e.Seller)
                   .HasForeignKey(e => e.SellerId);

            builder.HasMany(e => e.ProductsBought)
                   .WithOne(e => e.Buyer)
                   .HasForeignKey(e => e.BuyerId);
        }
    }
}
