using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.GameId);

            builder.HasOne(e => e.HomeTeam)
                   .WithMany(e => e.HomeGames)
                   .HasForeignKey(e => e.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.AwayTeam)
                   .WithMany(e => e.AwayGames)
                   .HasForeignKey(e => e.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.HomeTeamBetRate)
                   .HasColumnType("FLOAT");

            builder.Property(e => e.AwayTeamBetRate)
                   .HasColumnType("FLOAT");

            builder.Property(e => e.DrawBetRate)
                   .HasColumnType("FLOAT");

            builder.Property(e => e.Result)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);
        }
    }
}
