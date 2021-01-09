using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Services.Contracts
{
    public interface IFriendshipService
    {
        TModel ById<TModel>(int userId, int friendId);

        TModel ByName<TModel>(string userUserName, string friendUserName);

        bool Exists(int userId, int friendId);

        bool Exists(string userUserName, string friendUserName);

        ICollection<Friendship> GetFriends(int id);
    }
}
