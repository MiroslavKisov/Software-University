using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(e => e.BetId);

            builder.Property(e => e.Prediction)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.HasOne(e => e.Game)
                   .WithMany(e => e.Bets)
                   .HasForeignKey(e => e.GameId);

            builder.HasOne(e => e.User)
                   .WithMany(e => e.Bets)
                   .HasForeignKey(e => e.UserId);
        }
    }
}
