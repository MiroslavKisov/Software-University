namespace ManyToManyRelation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; } = new List<StudentCourse>();
    }
}
