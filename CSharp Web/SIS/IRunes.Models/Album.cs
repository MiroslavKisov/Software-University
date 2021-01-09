namespace IRunes.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Album : BaseModel<string>
    {
        public Album()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tracks = new HashSet<Track>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price => this.Tracks.Sum(e => e.Price) * 0.87m;

        public virtual ICollection<Track> Tracks{ get; set; }
    }
}
