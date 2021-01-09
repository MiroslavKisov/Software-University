using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class PlayerStatisticConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(e => new { e.GameId, e.PlayerId });

            builder.HasOne(e => e.Game)
                   .WithMany(e => e.PlayerStatistics)
                   .HasForeignKey(e => e.GameId);

            builder.HasOne(e => e.Player)
                   .WithMany(e => e.PlayerStatistics)
                   .HasForeignKey(e => e.PlayerId);
        }
    }
}
