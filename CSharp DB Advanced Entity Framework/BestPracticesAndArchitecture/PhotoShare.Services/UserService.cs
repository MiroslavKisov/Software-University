namespace PhotoShare.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using PhotoShare.Services.ExceptionMessages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly PhotoShareContext photoShareContext;
        private readonly IMapper mapper;

        public UserService(PhotoShareContext photoShareContext, IMapper mapper)
        {
            this.photoShareContext = photoShareContext;
            this.mapper = mapper;
        }

        public Friendship AcceptFriend(int userId, int friendId)
        {
            var friendShip = new Friendship()
            {
                UserId = friendId,
                FriendId = userId,
            };

            this.photoShareContext.Friendships.Add(friendShip);

            var friend = this.photoShareContext.Users.Where(e => e.Id == friendId).SingleOrDefault();

            friend.FriendsAdded.Add(friendShip);

            this.photoShareContext.SaveChanges();

            return friendShip;
        }

        public Friendship AddFriend(int userId, int friendId)
        {
            var friendShip = new Friendship()
            {
                UserId = userId,
                FriendId = friendId,
            };

            this.photoShareContext.Friendships.Add(friendShip);

            var user = this.photoShareContext.Users.Where(e => e.Id == userId).SingleOrDefault();

            user.FriendsAdded.Add(friendShip);

            this.photoShareContext.SaveChanges();

            return friendShip;
        }

        public TModel ById<TModel>(int id)
        {
            return By<TModel>(a => a.Id == id).SingleOrDefault();
        }

        public TModel ByUsername<TModel>(string username)
        {
            return By<TModel>(a => a.Username == username).SingleOrDefault();
        }

        public void ChangePassword(int userId, string password)
        {
            var user = this.photoShareContext
                           .Users
                           .Where(u => u.Id == userId)
                           .SingleOrDefault();

            user.Password = password;

            this.photoShareContext.SaveChanges();
        }

        public void Delete(string username)
        {
            var userId = ByUsername<User>(username).Id;
            var user = this.photoShareContext.Users.Find(userId);

            user.IsDeleted = true;

            this.photoShareContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return ById<User>(id) != null;
        }

        public bool Exists(string name)
        {
            return ByUsername<User>(name) != null;
        }

        public User Register(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
            };

            this.photoShareContext.Add(user);

            this.photoShareContext.SaveChanges();

            return user;
        }

        public void SetBornTown(int userId, int townId)
        {
            var user = this.photoShareContext.Users.Find(userId);

            var bornTown = this.photoShareContext.Towns.Find(townId);

            bornTown.UsersBornInTown.Add(user);

            this.photoShareContext.SaveChanges();
        }

        public void SetCurrentTown(int userId, int townId)
        {
            var user = this.photoShareContext.Users.Find(userId);

            var currentTown = this.photoShareContext.Towns.Find(townId);

            currentTown.UsersCurrentlyLivingInTown.Add(user);

            this.photoShareContext.SaveChanges();
        }

        public void LogIn(int id)
        {
            var user = this.photoShareContext.Users.Where(e => e.Id == id).SingleOrDefault();
            user.IsLoged = true;
            user.IsDeleted = false;

            this.photoShareContext.SaveChanges();
        }

        public ICollection<User> GetLoged()
        {
            var logedUsers = this.photoShareContext.Users.Where(e => e.IsLoged == true).ToList();

            return logedUsers;
        }

        public void LogOut(int id)
        {
            var user = this.photoShareContext.Users.Where(e => e.Id == id).SingleOrDefault();
            user.IsLoged = false;

            this.photoShareContext.SaveChanges();
        }

        private IEnumerable<TModel> By<TModel>(Func<User, bool> predicate)
            => this.photoShareContext
                   .Users
                   .Where(predicate)
                   .AsQueryable()
                   .ProjectTo<TModel>();
    }
}