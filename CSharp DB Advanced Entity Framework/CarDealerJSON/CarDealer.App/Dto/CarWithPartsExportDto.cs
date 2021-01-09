namespace CarDealer.App.Dto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class CarWithPartsExportDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}
