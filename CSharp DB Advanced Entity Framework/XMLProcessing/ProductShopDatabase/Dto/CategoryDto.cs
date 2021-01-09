namespace ProductShopDatabase.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("category")]
    public class CategoryDto
    {
        [MaxLength(15), MinLength(3)]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
