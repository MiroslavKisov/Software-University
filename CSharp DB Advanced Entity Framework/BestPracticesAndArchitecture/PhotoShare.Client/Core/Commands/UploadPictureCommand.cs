namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Dtos;
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using System.Linq;

    public class UploadPictureCommand : ICommand
    {
        private readonly IPictureService pictureService;
        private readonly IAlbumService albumService;
        private readonly IAlbumRoleService albumRoleService;
        private readonly IUserService userService;

        public UploadPictureCommand(IPictureService pictureService, IAlbumService albumService, IAlbumRoleService albumRoleService, IUserService userService)
        {
            this.albumRoleService = albumRoleService;
            this.pictureService = pictureService;
            this.albumService = albumService;
            this.userService = userService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string pictureTitle = data[1];
            string path = data[2];

            if (!this.userService.GetLoged().All(e => e.IsLoged == true))
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            
            var albumExists = this.albumService.Exists(albumName);

            if (!albumExists)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            var albumId = this.albumService.ByName<AlbumDto>(albumName).Id;

            var picture = this.pictureService.Create(albumId, pictureTitle, path);

            return string.Format(Messages.PictureSuccessfullyAddedToAlbum, pictureTitle, albumName);
        }
    }
}
