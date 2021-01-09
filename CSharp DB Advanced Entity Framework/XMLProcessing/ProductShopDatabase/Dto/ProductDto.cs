namespace ProductShopDatabase.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductDto
    {
        [MaxLength(100), MinLength(3)]
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
