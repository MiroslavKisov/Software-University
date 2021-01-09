namespace OneToManyRelations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
