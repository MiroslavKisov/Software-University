namespace ProductShopDatabase.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShopDatabase.Models;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.HasMany(e => e.CategoryProducts)
                   .WithOne(e => e.Product)
                   .HasForeignKey(e => e.ProductId);
        }
    }
}
