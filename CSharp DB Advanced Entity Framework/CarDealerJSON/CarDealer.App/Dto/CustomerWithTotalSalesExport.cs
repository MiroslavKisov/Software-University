namespace CarDealer.App.Dto
{
    using Newtonsoft.Json;

    public class CustomerWithTotalSalesExport
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
