using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(e => e.PositionId);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);
        }
    }
}
