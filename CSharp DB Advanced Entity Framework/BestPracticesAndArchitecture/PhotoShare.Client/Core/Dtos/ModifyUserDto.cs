﻿namespace PhotoShare.Client.Core.Dtos
{
    using Validation;

    public class ModifyUserDto
    {
        public string Username { get; set; }

        [Password(4, 20)]
        public string Password { get; set; }
    }
}
