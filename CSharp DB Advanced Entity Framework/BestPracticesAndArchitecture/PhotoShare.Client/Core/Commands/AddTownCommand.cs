namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Client.ExceptionMessages;
    using System.Linq;

    public class AddTownCommand : ICommand
    {
        private readonly ITownService townService;
        private readonly IUserService userService;

        public AddTownCommand(ITownService townService, IUserService userService)
        {
            this.townService = townService;
            this.userService = userService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            if (!this.userService.GetLoged().All(e => e.IsLoged == true))
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            string townName = data[0];
            string country = data[1];

            var townExists = this.townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException(string.Format(Messages.TownAlreadyAdded, townName));
            }

            var town = this.townService.Add(townName, country);

            return string.Format(Messages.TownAddedSuccessfully, townName);
        }
    }
}
