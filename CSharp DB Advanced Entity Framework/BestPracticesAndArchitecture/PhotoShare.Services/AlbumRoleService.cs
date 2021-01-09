namespace PhotoShare.Services
{
    using System;

    using Models;
    using Models.Enums;
    using Data;
    using Contracts;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;

    public class AlbumRoleService : IAlbumRoleService
    {
        private readonly PhotoShareContext context;

        public AlbumRoleService(PhotoShareContext context)
        {
            this.context = context;
        }

        public AlbumRole PublishAlbumRole(int albumId, int userId, string role)
        {
            var roleAsEnum = Enum.Parse<Role>(role, true);

            var albumRole = new AlbumRole()
            {
                AlbumId = albumId,
                UserId = userId,
                Role = roleAsEnum
            };


            var user = this.context.Users.Where(e => e.Id == userId).SingleOrDefault();
            var album = this.context.Albums.Where(e => e.Id == albumId).SingleOrDefault();

            user.AlbumRoles.Add(albumRole);
            album.AlbumRoles.Add(albumRole);

            //var albumRole = this.context.AlbumRoles.Where(e => e.AlbumId == albumId && e.UserId == userId).SingleOrDefault();

            //albumRole.Role = roleAsEnum;

            this.context.SaveChanges();
            return albumRole;
        }

        public TModel ById<TModel>(int id)
        {
            return By<TModel>(a => a.AlbumId == id).SingleOrDefault();
        }

        public bool Exists(int id)
        {
            return ById<AlbumRole>(id) != null;
        }

        public TModel ByUsername<TModel>(string albumName)
        {
            return By<TModel>(a => a.Album.Name == albumName).SingleOrDefault();
        }

        public bool Exists(string name)
        {
            return ByUsername<AlbumRole>(name) != null;
        }

        public ICollection<User> GetOwners(int albumId)
        {
            var owners = this.context
                             .Users
                             .Where(e => e.AlbumRoles.Any(s => s.AlbumId == albumId && s.Role == 0)).ToList();

            return owners;
        }

        private IEnumerable<TModel> By<TModel>(Func<AlbumRole, bool> predicate)
            => this.context
                   .AlbumRoles
                   .Where(predicate)
                   .AsQueryable()
                   .ProjectTo<TModel>();
    }
}
