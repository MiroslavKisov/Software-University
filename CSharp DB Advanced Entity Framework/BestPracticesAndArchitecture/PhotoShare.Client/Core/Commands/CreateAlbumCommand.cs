namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using Services.Contracts;


    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            var userName = data[0];
            var albumTitle = data[1];
            var bgColor = data[2];
            var tags = data.Skip(3).ToArray();

            var userExists = this.userService.Exists(userName);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound), userName);
            }

            var user = this.userService.ByUsername<User>(userName);

            if (!user.IsLoged)
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            if (user.IsDeleted)
            {
                throw new InvalidOperationException(string.Format(Messages.UserAlreadyDeleted, userName));
            }

            var userId = this.userService.ByUsername<User>(userName).Id;
            var albumExists = this.albumService.Exists(albumTitle);

            if (albumExists)
            {
                throw new ArgumentException(string.Format(Messages.AlbumExists, albumTitle));
            }

            var containsColor = Enum.IsDefined(typeof(Color), bgColor);

            if (!containsColor)
            {
                throw new ArgumentException(string.Format(Messages.BackgroundColorDoesNotExist, bgColor));
            }

            foreach (var tag in tags)
            {
                if (!this.tagService.Exists(tag))
                {
                    throw new ArgumentException(Messages.InvalidTags);
                }
            }

            this.albumService.Create(userId, albumTitle, bgColor, tags);

            return string.Format(Messages.AlbumSuccessfullyCreated, albumTitle);
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
