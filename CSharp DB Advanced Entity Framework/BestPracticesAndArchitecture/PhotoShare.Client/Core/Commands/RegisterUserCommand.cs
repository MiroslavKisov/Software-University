namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.ExceptionMessages;
    using PhotoShare.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string passwordMatch = data[2];
            string email = data[3];

            var registerUserDto = new RegisterUserDto()
            {
                Username = username,
                Password = password,
                Email = email
            };

            if (!IsValid(registerUserDto))
            {
                throw new ArgumentException(Messages.InvalidData);
            }

            var userExists = this.userService.Exists(username);

            if (userExists)
            {
                throw new InvalidOperationException(string.Format(Messages.UserAlreadyExists, username));
            }

            if (password != passwordMatch)
            {
                throw new ArgumentException(Messages.PasswordsDoNotMatch);
            }

            this.userService.Register(username, password, email);

            return string.Format(Messages.UserNameRegisteredSuccessfully, username);

        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
