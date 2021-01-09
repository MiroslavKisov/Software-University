namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IAlbumService albumService;
        private readonly IAlbumRoleService albumRoleService;

        public ShareAlbumCommand(IUserService userService, IAlbumService albumService, IAlbumRoleService albumRoleService)
        {
            this.albumRoleService = albumRoleService;
            this.albumService = albumService;
            this.userService = userService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            var albumId = int.Parse(data[0]);
            var userName = data[1];
            var permission = data[2];

            var userExists = this.userService.Exists(userName);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound, userName));
            }

            var user = this.userService.ByUsername<User>(userName);
            var userId = this.userService.ByUsername<User>(userName).Id;
            var albumExists = this.albumService.Exists(albumId);

            if (!albumExists)
            {
                throw new ArgumentException(string.Format(Messages.AlbumDoesNotExist, albumId));
            }

            if (!user.IsLoged)
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            var owners = this.albumRoleService.GetOwners(albumId);

            if (!owners.Any(e => e.Username == userName))
            {
                throw new ArgumentException(string.Format(Messages.DoesNotOwnThisAlbum, userName));
            }

            this.albumRoleService.PublishAlbumRole(albumId, userId, permission);

            return string.Format(Messages.AlbumSharedSuccessfully, userName, albumId, permission);
        }
    }
}
