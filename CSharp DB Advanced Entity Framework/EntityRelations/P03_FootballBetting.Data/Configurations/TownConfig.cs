using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class TownConfig : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(e => e.TownId);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.HasOne(e => e.Country)
                   .WithMany(e => e.Towns)
                   .HasForeignKey(e => e.CountryId);
        }
    }
}
