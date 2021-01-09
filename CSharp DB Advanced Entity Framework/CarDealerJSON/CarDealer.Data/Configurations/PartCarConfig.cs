namespace CarDealer.Data.Configurations
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class PartCarConfig : IEntityTypeConfiguration<PartCar>
    {
        public void Configure(EntityTypeBuilder<PartCar> builder)
        {
            builder.HasKey(e => new { e.PartId, e.CarId });

            builder.HasOne(e => e.Car)
                   .WithMany(e => e.CarParts)
                   .HasForeignKey(e => e.CarId);

            builder.HasOne(e => e.Part)
                   .WithMany(e => e.CarParts)
                   .HasForeignKey(e => e.PartId);
        }
    }
}
