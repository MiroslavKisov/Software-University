using PhotoShare.Client.Core.Contracts;
using PhotoShare.Client.ExceptionMessages;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand : ICommand
    {
        private readonly IUserService userService;

        public LogoutCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            var userName = args[0];

            var userExist = this.userService.Exists(userName);

            if (!userExist)
            {
                throw new ArgumentException(Messages.UserNotFound, userName);
            }

            var userId = this.userService.ByUsername<User>(userName).Id;

            var user = this.userService.ByUsername<User>(userName);

            if (!user.IsLoged)
            {
                throw new InvalidOperationException(Messages.LogInFirst);
            }

            this.userService.LogOut(userId);
            return string.Format(Messages.UserLogedOut, userName);
        }
    }
}
