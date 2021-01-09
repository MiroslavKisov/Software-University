namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;
        private const string Password = "Password";
        private const string CurrentTown = "CurrentTown";
        private const string BornTown = "BornTown";

        public ModifyUserCommand(IUserService userService, ITownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            var userName = data[0];
            var property = data[1];

            string result = null;

            if (property == Password)
            {
                var exists = this.userService.Exists(userName);
                
                var newPassword = data[2];

                if (!exists)
                {
                    throw new ArgumentException(Messages.UserNotFound, userName);
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

                var modifyUserDto = new ModifyUserDto()
                {
                    Username = userName,
                    Password = newPassword,
                };

                if (!IsValid(modifyUserDto))
                {
                    throw new ArgumentException(Messages.InvalidPassword);
                }

                this.userService.ChangePassword(userId, newPassword);

                result = Messages.PasswordChanged;
            }
            else if (property == BornTown)
            {
                var userExists = this.userService.Exists(userName);


                var newBornTownName = data[2];

                if (!userExists)
                {
                    throw new ArgumentException(Messages.UserNotFound, userName);
                }

                var userId = this.userService.ByUsername<User>(userName).Id;

                var townExists = this.townService.Exists(newBornTownName);

                if (!townExists)
                {
                    throw new ArgumentException(Messages.TownNotFound);
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

                var townId = this.townService.ByName<Town>(newBornTownName).Id;

                this.userService.SetBornTown(userId, townId);

                result = string.Format(Messages.BornTownChanged, newBornTownName);
            }
            else if (property == CurrentTown)
            {
                var userExists = this.userService.Exists(userName);

                var currentTownName = data[2];

                if (!userExists)
                {
                    throw new ArgumentException(Messages.UserNotFound, userName);
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

                var townExists = this.townService.Exists(currentTownName);

                if (!townExists)
                {
                    throw new ArgumentException(Messages.TownNotFound, userName);
                }


                var townId = this.townService.ByName<Town>(currentTownName).Id;

                this.userService.SetCurrentTown(userId, townId);

                result = string.Format(Messages.CurrentTownChanged, currentTownName);
            }

            return result;
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
