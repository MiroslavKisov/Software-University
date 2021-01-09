namespace PhotoShare.Services
{
    using AutoMapper.QueryableExtensions;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FriendshipService : IFriendshipService
    {
        private readonly PhotoShareContext photoShareContext;

        public FriendshipService(PhotoShareContext photoShareContext)
        {
            this.photoShareContext = photoShareContext;
        }

        public TModel ById<TModel>(int userId, int friendId)
        {
            return By<TModel>(a => a.UserId == userId && a.FriendId == friendId).SingleOrDefault();
        }

        public TModel ByName<TModel>(string userUserName, string friendUserName)
        {
            return By<TModel>(a => a.User.Username == userUserName && a.Friend.Username == friendUserName).SingleOrDefault();
        }

        public bool Exists(int userId, int friendId)
        {
            return ById<Friendship>(userId, friendId) != null;
        }

        public bool Exists(string userUserName, string friendUserName)
        {
            return ByName<Friendship>(userUserName, friendUserName) != null;
        }

        private IEnumerable<TModel> By<TModel>(Func<Friendship, bool> predicate) =>
            this.photoShareContext.Friendships
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();

        public ICollection<Friendship> GetFriends(int id)
        {
            var friends = this.photoShareContext.Friendships.Where(e => e.UserId == id).ToList();
            return friends;
        }
    }
}
