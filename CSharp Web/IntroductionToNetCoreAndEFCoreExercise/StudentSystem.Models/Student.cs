namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

        public ICollection<Homework> HomeworkSubmissions { get; set; } = new List<Homework>();
    }
}
