namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using PhotoShare.Models.Enums;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext photoShareContext;

        public AlbumService(PhotoShareContext photoShareContext)
        {
            this.photoShareContext = photoShareContext;
        }

        public TModel ById<TModel>(int id)
        {
            return By<TModel>(a => a.Id == id).SingleOrDefault();
        }

        public TModel ByName<TModel>(string name)
        {
            return By<TModel>(a => a.Name == name).SingleOrDefault();
        }

        public Album Create(int userId, string albumTitle, string BgColor, string[] tags)
        {
            var album = new Album()
            {
                Name = albumTitle,
                BackgroundColor = Enum.Parse<Color>(BgColor, true),
            };

            this.photoShareContext.Albums.Add(album);
            this.photoShareContext.SaveChanges();

            var albumRole = new AlbumRole()
            {
                UserId = userId,
                Album = album,
            };

            this.photoShareContext.AlbumRoles.Add(albumRole);
            this.photoShareContext.SaveChanges();

            foreach (var tag in tags)
            {
                var tagId = this.photoShareContext.Tags.FirstOrDefault(x => x.Name == tag).Id;

                var albumTag = new AlbumTag()
                {
                    TagId = tagId,
                    Album = album
                };

                this.photoShareContext.AlbumTags.Add(albumTag);
            }

            this.photoShareContext.SaveChanges();

            return album;
        }

        public bool Exists(int id)
        {
            return ById<Album>(id) != null;
        }

        public bool Exists(string name)
        {
            return ByName<Album>(name) != null;
        }

        private IEnumerable<TModel> By<TModel>(Func<Album, bool> predicate)
        {
            return this.photoShareContext
                       .Albums
                       .Where(predicate)
                       .AsQueryable()
                       .ProjectTo<TModel>();
        }
    }
}
