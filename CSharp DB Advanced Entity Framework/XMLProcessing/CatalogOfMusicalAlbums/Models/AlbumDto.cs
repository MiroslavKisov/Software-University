namespace CatalogOfMusicalAlbums.Models
{
    using System.Xml.Serialization;

    [XmlType("album")]
    public class AlbumDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("artist")]
        public string Artist { get; set; }

        [XmlElement("year")]
        public string Year { get; set; }

        [XmlElement("producer")]
        public string Producer { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlArrayItem("song")]
        public SongDto[] songs { get; set; }
    }
}
