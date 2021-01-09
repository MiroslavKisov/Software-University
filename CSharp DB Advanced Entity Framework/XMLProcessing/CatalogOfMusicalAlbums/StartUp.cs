namespace CatalogOfMusicalAlbums
{
    using CatalogOfMusicalAlbums.Models;
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var catalog = GetCatalog();
            var serializer = new XmlSerializer(typeof(CatalogDto), new XmlRootAttribute("catalog"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            using (var writer = new StreamWriter("catalog.xml"))
            {
                serializer.Serialize(writer, catalog, namespaces);
            }
        }

        private static CatalogDto GetCatalog()
        {
            var catalog = new CatalogDto()
            {
                albums = new AlbumDto[]
                {
                    new AlbumDto()
                    {
                        Name = "Load",
                        Artist = "Metallica",
                        Year = "1996",
                        Producer = "Bob Rock",
                        Price = 9.99m,
                        songs = new SongDto[]
                        {
                            new SongDto()
                            {
                                Title = "Until It Sleeps",
                                Duration = "2.33",
                            },
                        
                            new SongDto()
                            {
                                Title = "Mama Said",
                                Duration = "5.12",
                            },
                        
                            new SongDto()
                            {
                                Title = "King Nothing",
                                Duration = "6.12",
                            },
                        }
                    },

                    new AlbumDto()
                    {
                        Name = "Reload",
                        Artist = "Metallica",
                        Year = "1999",
                        Producer = "Bob Rock",
                        Price = 9.99m,
                        songs = new SongDto[]
                        {
                            new SongDto()
                            {
                                Title = "Fuel",
                                Duration = "3.43",
                            },
                        
                            new SongDto()
                            {
                                Title = "Memory Remains",
                                Duration = "5.52",
                            },
                        
                            new SongDto()
                            {
                                Title = "Unforgiven II",
                                Duration = "3.50",
                            },
                        },
                    }
                }
            };

            return catalog;
        }
    }
}


