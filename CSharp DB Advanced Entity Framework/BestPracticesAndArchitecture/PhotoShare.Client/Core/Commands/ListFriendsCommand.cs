using PhotoShare.Client.Core.Contracts;
using PhotoShare.Client.ExceptionMessages;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Linq;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class ListFriendsCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IFriendshipService friendshipService;

        public ListFriendsCommand(IUserService userService, IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            var userName = args[0];
            //var userFriends = this.userService.ByUsername<User>(userName).FriendsAdded.ToList();
            var userId = this.userService.ByUsername<User>(userName).Id;
            
            var userExists = this.userService.Exists(userId);

            if (!userExists)
            {
                throw new ArgumentException(Messages.UserNotFound, userName);
            }

            var userFriends = this.friendshipService.GetFriends(userId);

            if (userFriends.Count == 0)
            {
                throw new InvalidOperationException(Messages.NoFriendsForThisUser);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Messages.Friends);

            foreach (var friend in userFriends.OrderBy(x => x.Friend.Username))
            {
                sb.AppendLine("  -" + friend.Friend.Username);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
