namespace StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using StudentSystem.Models;
    using System;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasMany(e => e.Licences)
                   .WithOne(e => e.Resource)
                   .HasForeignKey(e => e.ResourceId);
        }
    }
}
