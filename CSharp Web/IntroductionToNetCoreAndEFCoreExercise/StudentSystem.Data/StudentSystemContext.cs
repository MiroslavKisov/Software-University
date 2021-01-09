namespace StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data.Configurations;
    using StudentSystem.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public StudentSystemContext()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        }
    }
}
