namespace ShopHierarchy
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ItemOrder> ItemsOrders { get; set; } = new List<ItemOrder>();
    }
}
