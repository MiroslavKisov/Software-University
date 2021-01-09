namespace CarDealer.App.Dto
{
    using CarDealer.Models;
    using System;

    public class CustomerExportDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual Sale[] Sales { get; set; } = new Sale[0];
    }
}
