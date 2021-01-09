namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Models;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string userName = data[0];

            var userExists = this.userService.Exists(userName);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound, userName));
            }

            var user = this.userService.ByUsername<User>(userName);

            if (!user.IsLoged)
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            var isDeleted = user.IsDeleted;

            if (isDeleted)
            {
                throw new InvalidOperationException(string.Format(Messages.UserAlreadyDeleted, userName));
            }

            this.userService.Delete(userName);
            
            return string.Format(Messages.UserDeletedSuccessfully, userName);
        }
    }
}
