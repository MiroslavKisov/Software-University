namespace StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(e => new { e.StudentId, e.CourseId });
        }
    }
}
