namespace ShopHierarchy
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Salesman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
