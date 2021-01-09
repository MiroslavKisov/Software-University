namespace ProductShopDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.CategoryProducts = new List<CategoryProducts>();
        }

        public int Id { get; set; }

        [MaxLength(100), MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? BuyerId { get; set; }
        public User Buyer { get; set; }

        public int SellerId { get; set; }
        public User Seller { get; set; }

        public ICollection<CategoryProducts> CategoryProducts { get; set; }
    }
}
