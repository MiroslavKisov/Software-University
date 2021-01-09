namespace StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using StudentSystem.Models;
    using System;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(e => e.HomeworkSubmissions)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentId);

            builder.HasMany(e => e.Courses)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentId);
        }
    }
}
