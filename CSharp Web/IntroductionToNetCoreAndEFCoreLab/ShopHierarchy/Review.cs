﻿namespace ShopHierarchy
{
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
