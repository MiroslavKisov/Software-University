namespace SIS.HTTP.Common
{
    public static class Messages
    {
        public const string NotValidObject = "Object {0} cannot be null!";

        public const string NotValidString = "String {0} cannot be null or empty!";

        public const string BadRequestMessage = "The Request was malformed or contains unsupported elements.";

        public const string InternalServerErrorMessage = "The Server has encountered an error.";

        public const string InvalidUsername = "Username must be at least 4 characters";

        public const string SameUsername = "User with the same username already exists.";

        public const string InvalidPassword = "Password is either null or less than 6 characters.";

        public const string DifferentPasswords = "Password and Confirm Password must be the same.";

        public const string InvalidUsernameOrPassword = "Invalid Username or Password!";

        public const string InvalidEmail = "There is already account registered to that email";
    }
}
