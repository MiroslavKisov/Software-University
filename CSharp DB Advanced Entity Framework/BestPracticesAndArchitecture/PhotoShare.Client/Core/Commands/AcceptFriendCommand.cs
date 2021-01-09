namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IFriendshipService friendshipService;

        public AcceptFriendCommand(IUserService userService, IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
            this.userService = userService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string[] data)
        {
            var friendUserName = data[0];
            var userUserName = data[1];

            var friendExist = this.userService.Exists(friendUserName);

            if (!friendExist)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound, friendUserName));
            }

            var userExist = this.userService.Exists(userUserName);

            if (!userExist)
            {
                throw new ArgumentException(string.Format(Messages.UserNotFound, userUserName));
            }

            var friendId = this.userService.ByUsername<User>(friendUserName).Id;
            var userId = this.userService.ByUsername<User>(userUserName).Id;

            var isFriendRequest = this.friendshipService.Exists(userId, friendId);

            if (!isFriendRequest)
            {
                throw new InvalidOperationException(string.Format(Messages.NoSuchFriendRequest, userUserName, friendUserName));
            }

            var areFriends01 = this.friendshipService.Exists(userId, friendId);
            var areFriends02 = this.friendshipService.Exists(friendId, userId);

            if (areFriends01 && areFriends02)
            {
                throw new InvalidOperationException(string.Format(Messages.TheyAreAlreadyFriends, friendUserName, userUserName));
            }

            this.userService.AcceptFriend(userId, friendId);

            return string.Format(Messages.FriendAccepted, friendUserName, userUserName);
        }
    }
}
