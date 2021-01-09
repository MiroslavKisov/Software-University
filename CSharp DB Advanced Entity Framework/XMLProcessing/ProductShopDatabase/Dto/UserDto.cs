namespace ProductShopDatabase.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [MaxLength(100), MinLength(3)]
        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }
    }
}
