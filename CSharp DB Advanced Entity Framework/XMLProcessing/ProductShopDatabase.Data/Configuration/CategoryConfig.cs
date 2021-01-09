namespace ProductShopDatabase.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShopDatabase.Models;

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.HasMany(e => e.CategoryProducts)
                   .WithOne(e => e.Category)
                   .HasForeignKey(e => e.CategoryId);
        }
    }
}
