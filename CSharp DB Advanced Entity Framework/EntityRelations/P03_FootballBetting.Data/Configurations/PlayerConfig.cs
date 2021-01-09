using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.PlayerId);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.HasOne(e => e.Team)
                   .WithMany(e => e.Players)
                   .HasForeignKey(e => e.TeamId);

            builder.HasOne(e => e.Position)
                   .WithMany(e => e.Players)
                   .HasForeignKey(e => e.PositionId);
        }
    }
}
