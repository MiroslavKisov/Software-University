namespace ShopHierarchy
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ItemOrder> ItemsOrders { get; set; } = new List<ItemOrder>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
