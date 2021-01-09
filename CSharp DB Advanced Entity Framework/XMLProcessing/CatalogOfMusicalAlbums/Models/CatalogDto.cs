namespace CatalogOfMusicalAlbums.Models
{
    using System.Xml.Serialization;

    public class CatalogDto
    {
        [XmlArrayItem("album")]
        public AlbumDto[] albums { get; set; }
    }
}
