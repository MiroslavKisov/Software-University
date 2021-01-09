namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
            this.CarParts = new List<PartCar>();
        }

        public int Id { get; set; }

        public string  Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public virtual ICollection<PartCar> CarParts { get; set; }
    }
}
