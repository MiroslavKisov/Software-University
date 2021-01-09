namespace CarDealer.Data.Configurations
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Sales)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
        }
    }
}
