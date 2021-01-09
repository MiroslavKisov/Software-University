namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Part
    {
        public Part()
        {
            this.CarParts = new List<PartCar>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public int SuplierId { get; set; }
        public Supplier Supplier { get; set; }

        public virtual ICollection<PartCar> CarParts { get; set; }
    }
}
