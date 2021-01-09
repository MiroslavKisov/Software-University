namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;

    public class AlbumTagService : IAlbumTagService
    {
        private readonly PhotoShareContext photoShareContext;

        public AlbumTagService(PhotoShareContext photoShareContext)
        {
            this.photoShareContext = photoShareContext;
        }

        public AlbumTag AddTagTo(int albumId, int tagId)
        {
            //var album = this.photoShareContext.Albums.Find(albumId);

            //var tag = this.photoShareContext.Tags.Find(tagId);

            var albumTag = new AlbumTag()
            {
                AlbumId = albumId,
                TagId = tagId,
            };

            this.photoShareContext.AlbumTags.Add(albumTag);

            this.photoShareContext.SaveChanges();

            return albumTag;
        }
    }
}
