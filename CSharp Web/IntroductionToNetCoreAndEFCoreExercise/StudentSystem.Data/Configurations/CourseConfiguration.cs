namespace StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using StudentSystem.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasMany(e => e.HomeworkSubmissions)
                   .WithOne(e => e.Course)
                   .HasForeignKey(e => e.CourseId);

            builder.HasMany(e => e.Resources)
                   .WithOne(e => e.Course)
                   .HasForeignKey(e => e.CourseId);

            builder.HasMany(e => e.Students)
                   .WithOne(e => e.Course)
                   .HasForeignKey(e => e.CourseId);
        }
    }
}
