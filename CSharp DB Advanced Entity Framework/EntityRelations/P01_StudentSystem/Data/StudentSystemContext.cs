using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Configuration;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                      .IsRequired(false)
                      .IsUnicode(false)
                      .HasColumnType("CHAR(10)");

                entity.Property(e => e.RegisteredOn);

                entity.Property(e => e.Birthday)
                      .IsRequired(false);

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(80);

                entity.Property(e => e.Description)
                      .IsRequired(false)
                      .IsUnicode(true);

                entity.Property(e => e.Price)
                      .IsRequired(true);

            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(50);

                entity.Property(e => e.Url)
                      .IsRequired(true)
                      .IsUnicode(false);

                entity.HasOne(e => e.Course)
                      .WithMany(e => e.Resources)
                      .HasForeignKey(e => e.CourseId);

            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                      .IsRequired(true)
                      .IsUnicode(false);

                entity.HasOne(e => e.Student)
                      .WithMany(e => e.HomeworkSubmissions)
                      .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                      .WithMany(e => e.HomeworkSubmissions)
                      .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(e => e.Student)
                      .WithMany(e => e.CourseEnrollments)
                      .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                      .WithMany(e => e.StudentsEnrolled)
                      .HasForeignKey(e => e.CourseId);
            });
        }
    }
}
