using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.Username)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.Password)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.Email)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.Name)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);
        }
    }
}
