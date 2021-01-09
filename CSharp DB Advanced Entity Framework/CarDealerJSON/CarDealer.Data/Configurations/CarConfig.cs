namespace CarDealer.Data.Configurations
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Sales)
                   .WithOne(e => e.Car)
                   .HasForeignKey(e => e.CarId);
        }
    }
}
