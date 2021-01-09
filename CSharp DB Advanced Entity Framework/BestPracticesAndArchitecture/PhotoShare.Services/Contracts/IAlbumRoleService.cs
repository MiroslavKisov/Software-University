namespace PhotoShare.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface IAlbumRoleService
    {
        AlbumRole PublishAlbumRole(int albumId, int userId, string role);

        TModel ById<TModel>(int id);

        TModel ByUsername<TModel>(string albumName);

        bool Exists(int id);

        bool Exists(string name);

        ICollection<User> GetOwners(int albumId);
    }
}
