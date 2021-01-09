using PhotoShare.Client.Core.Contracts;
using PhotoShare.Client.ExceptionMessages;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            var userName = args[0];
            var password = args[1];

            var userExist = this.userService.Exists(userName);

            if (!userExist)
            {
                throw new ArgumentException(Messages.UserNotFound, userName);
            }

            var user = this.userService.ByUsername<User>(userName);

            var isLogedIn = user.IsLoged;

            if (isLogedIn)
            {
                throw new ArgumentException(Messages.LogOutFirst);
            }

            var isPasswordCorrect = user.Password == password;
            var isUsernameCorrect = user.Username == userName;

            if (!isPasswordCorrect || !isUsernameCorrect)
            {
                throw new ArgumentException(Messages.InvalidUserNameOrPassword);
            }

            var userId = this.userService.ByUsername<User>(userName).Id;

            this.userService.LogIn(userId);

            return string.Format(Messages.UserLogedIn, userName);
        }
    }
}
