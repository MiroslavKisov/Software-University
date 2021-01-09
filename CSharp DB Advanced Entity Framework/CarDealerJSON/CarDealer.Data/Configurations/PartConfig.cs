namespace CarDealer.Data.Configurations
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class PartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
