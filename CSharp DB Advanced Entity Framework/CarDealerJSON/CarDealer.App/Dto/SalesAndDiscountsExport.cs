namespace CarDealer.App.Dto
{
    using Newtonsoft.Json;

    public class SalesAndDiscountsExport
    {
        [JsonProperty("car")]
        public SaleCarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public decimal Discount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
