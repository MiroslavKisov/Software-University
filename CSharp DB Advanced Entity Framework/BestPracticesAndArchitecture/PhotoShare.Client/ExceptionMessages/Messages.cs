using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Client.ExceptionMessages
{
    public class Messages
    {
        public const string PasswordsDoNotMatch = "Passwords do not match!";

        public const string UserAlreadyExists = "User {0} already exists!";

        public const string InvalidData = "Invalid data!";

        public const string UserNameRegisteredSuccessfully = "User {0} registered successfully!";

        public const string InvalidAlbum = "Invalid album ID!";

        public const string TownAddedSuccessfully = "Town {0} was added successfully!";

        public const string TownAlreadyAdded = "Town {0} was already added!";

        public const string UserNotFound = "User {0} not found!";

        public const string TownNotFound = "Town {0} not found!";

        public const string PasswordChanged = "Password changed successfully";

        public const string BornTownChanged = "BornTown changed to {0}";

        public const string CurrentTownChanged = "Current Town changed {0}";

        public const string InvalidPassword = "Invalid Password";

        public const string UserDeletedSuccessfully = "User {0} was deleted successfully!";

        public const string UserAlreadyDeleted = "User {0} already deleted!";

        public const string TagAddedSuccessfully = "Tag {0} was added successfully!";

        public const string TagExist = "Tag {0} exists!";

        public const string AlbumSuccessfullyCreated = "Album {0} successfully created!";

        public const string AlbumExists = "Album {0} exists!";

        public const string BackgroundColorDoesNotExist = "Color {0} not found!";

        public const string InvalidTags = "Invalid tags!";

        public const string TagAddedSuccessfullyToAlbum = "Tag {0} added to {1}!";

        public const string TagOrAlbumDoesNotExists = "Either tag or album do not exist!";

        public const string FriendAddedSuccessfully = "Friend {1} added to {0}";

        public const string TheyAreAlreadyFriends = "{1} is already a friend to {0}";

        public const string AnyOfTheUsersDoNotExist = "{0} not found!";

        public const string FriendAccepted = "{0} accepted {1} as a friend";

        public const string NoSuchFriendRequest = "{1} has not added {0} as a friend";

        public const string NoFriendsForThisUser = "No friends for this user :(";

        public const string Friends = "Friends:";

        public const string AlbumSharedSuccessfully = "Username {0} added to album {1} ({2})";

        public const string AlbumDoesNotExist = "Album {0} not found!";

        public const string PermissionNotvalid = "Permission must be either “Owner” or “Viewer”!";

        public const string PictureSuccessfullyAddedToAlbum = "Picture {0} added to {1}!";

        public const string InvalidUserNameOrPassword = "Invalid username or password!";

        public const string UserLogedIn = "User {0} successfully logged in!";

        public const string LogOutFirst = "You should logout first!";

        public const string UserLogedOut = "User {0} successfully logged out!";

        public const string LogInFirst = "You should log in first in order to logout.";

        public const string InvalidCredentials = "Invalid credentials! Log In First!";

        public const string DoesNotOwnThisAlbum = "{0} does not own this album!";
    }
}
