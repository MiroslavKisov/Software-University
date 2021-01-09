namespace ProductShopDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.ProductsBought = new List<Product>();
            this.ProductsSold = new List<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [MaxLength(100), MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> ProductsBought { get; set; }

        public ICollection<Product> ProductsSold { get; set; }
    }
}
