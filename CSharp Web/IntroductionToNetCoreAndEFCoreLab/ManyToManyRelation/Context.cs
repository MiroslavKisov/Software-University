using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToManyRelation
{
    public class Context : DbContext
    {
        private const string connectionString = @"server=.;Database=ManyToManyDb;integrated security=true";

        public Context(DbContextOptions options)
            : base(options)
        {
        }

        public Context()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(e => e.Course)
                .WithMany(e => e.StudentsCourses)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(e => e.Student)
                .WithMany(e => e.StudentsCourses)
                .HasForeignKey(e => e.StudentId);
        }
    }
}
