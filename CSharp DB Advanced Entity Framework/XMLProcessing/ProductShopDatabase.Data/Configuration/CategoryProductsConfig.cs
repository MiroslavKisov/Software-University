namespace ProductShopDatabase.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShopDatabase.Models;

    public class CategoryProductsConfig : IEntityTypeConfiguration<CategoryProducts>
    {
        public void Configure(EntityTypeBuilder<CategoryProducts> builder)
        {
            builder.HasKey(e => new { e.CategoryId, e.ProductId });
        }
    }
}
