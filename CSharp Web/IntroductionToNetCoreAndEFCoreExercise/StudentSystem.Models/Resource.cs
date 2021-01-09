namespace StudentSystem.Models
{
    using StudentSystem.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //: id, name, type of resource (video / presentation / document / other), URL
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string URL { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<License> Licences { get; set; } = new List<License>();
    }
}
