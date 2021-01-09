namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using Dtos;
    using ExceptionMessages;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IUserService userService;

        public AddTagCommand(ITagService tagService, IUserService userService)
        {
            this.userService = userService;
            this.tagService = tagService;
        }

        public string Execute(string[] args)
        {
            if (!this.userService.GetLoged().All(e => e.IsLoged == true))
            {
                throw new InvalidOperationException(Messages.InvalidCredentials);
            }

            string tagName = args[0];

            var exists = this.tagService.Exists(tagName);

            if (exists)
            {
                throw new ArgumentException(string.Format(Messages.TagExist, tagName));
            }

            var tagDto = new TagDto()
            {
                Name = "#" + tagName,
            };

            if (!IsValid(tagDto))
            {
                throw new ArgumentException(Messages.InvalidData);
            }

            this.tagService.AddTag(tagName);

            return string.Format(Messages.TagAddedSuccessfully, tagName);
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
