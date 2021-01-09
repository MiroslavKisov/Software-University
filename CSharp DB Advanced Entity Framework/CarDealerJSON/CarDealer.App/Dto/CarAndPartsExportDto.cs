namespace CarDealer.App.Dto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class CarAndPartsExportDto
    {
        [JsonProperty("car")]
        public CarWithPartsExportDto Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<PartExportDto> Parts { get; set; }
    }
}
