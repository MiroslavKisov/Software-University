namespace ProductShopDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new List<CategoryProducts>();
        }

        public int Id { get; set; }

        [MaxLength(15), MinLength(3)]
        public string Name { get; set; }

        public ICollection<CategoryProducts> CategoryProducts { get; set; }
    }
}
