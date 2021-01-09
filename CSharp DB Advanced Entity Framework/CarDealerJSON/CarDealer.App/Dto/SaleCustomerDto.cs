namespace CarDealer.App.Dto
{
    using Newtonsoft.Json;

    public class SaleCustomerDto
    {
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
    }
}
