namespace IRunes.Models
{
    using System;

    public class Track : BaseModel<string>
    {
        public Track()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
