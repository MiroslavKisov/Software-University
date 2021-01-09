namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IFriendshipService friendshipService;

        public AddFriendCommand(IUserService userService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.friendshipService = friendshipService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            var userUserName = data[0];
            var friendUserName = data[1];

            var userExist = this.userService.Exists(userUserName);

            if (!userExist)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound, userUserName));
            }

            var user = this.userService.ByUsername<User>(userUserName);

            if (!user.IsLoged)
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            var friendExist = this.userService.Exists(friendUserName);

            if (!friendExist)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound, friendUserName));
            }

            var userId = this.userService.ByUsername<User>(userUserName).Id;
            var friendId = this.userService.ByUsername<User>(friendUserName).Id;
            var areFriends = this.friendshipService.Exists(userId, friendId);

            if (areFriends)
            {
                throw new InvalidOperationException(string.Format(Messages.TheyAreAlreadyFriends, userUserName, friendUserName));
            }

            this.userService.AddFriend(userId, friendId);

            return string.Format(Messages.FriendAddedSuccessfully, userUserName, friendUserName);
        }
    }
}
