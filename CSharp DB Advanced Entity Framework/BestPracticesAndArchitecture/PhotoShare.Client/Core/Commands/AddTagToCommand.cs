namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IAlbumService albumService;
        private readonly IAlbumTagService albumTagService;
        private readonly IAlbumRoleService albumRoleService;
        private readonly IUserService userService;

        public AddTagToCommand(ITagService tagService, IAlbumService albumService, IAlbumTagService albumTagService, IAlbumRoleService albumRoleService, IUserService userService)
        {
            this.albumRoleService = albumRoleService;
            this.tagService = tagService;
            this.albumService = albumService;
            this.albumTagService = albumTagService;
            this.userService = userService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] args)
        {
            var albumName = args[0];
            var tagName = args[1];

            var albumExists = this.albumService.Exists(albumName);
            var tagExists = this.tagService.Exists(tagName);

            if (!tagExists || !albumExists)
            {
                throw new ArgumentException(Messages.TagOrAlbumDoesNotExists);
            }

            var albumId = this.albumService.ByName<Album>(albumName).Id;
            var tagId = this.tagService.ByName<Tag>(tagName).Id;

            if (this.albumRoleService.GetOwners(albumId).All(e => e.IsLoged == true))
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            this.albumTagService.AddTagTo(albumId, tagId);

            return string.Format(Messages.TagAddedSuccessfullyToAlbum, tagName, albumName);
        }
    }
}
