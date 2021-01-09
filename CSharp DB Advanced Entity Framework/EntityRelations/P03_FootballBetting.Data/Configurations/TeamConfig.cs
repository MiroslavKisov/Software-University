using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.TeamId);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.LogoUrl)
                   .IsRequired(true)
                   .IsUnicode(false);

            builder.Property(e => e.Initials)
                   .IsRequired(true)
                   .IsUnicode(false)
                   .HasColumnType("CHAR(3)");

            builder.HasOne(e => e.PrimaryKitColor)
                   .WithMany(e => e.PrimaryKitTeams)
                   .HasForeignKey(e => e.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SecondaryKitColor)
                   .WithMany(e => e.SecondaryKitTeams)
                   .HasForeignKey(e => e.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Town)
                   .WithMany(e => e.Teams)
                   .HasForeignKey(e => e.TownId);
        }
    }
}
