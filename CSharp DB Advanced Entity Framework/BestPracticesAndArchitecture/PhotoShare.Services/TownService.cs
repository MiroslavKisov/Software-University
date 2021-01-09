using AutoMapper.QueryableExtensions;
using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoShare.Services
{
    public class TownService : ITownService
    {
        private readonly PhotoShareContext photoShareContext;

        public TownService(PhotoShareContext photoShareContext)
        {
            this.photoShareContext = photoShareContext;
        }

        public Town Add(string townName, string countryName)
        {
            var town = new Town()
            {
                Name = townName,
                Country = countryName,
            };

            this.photoShareContext.Towns.Add(town);

            this.photoShareContext.SaveChanges();

            return town;
        }

        public TModel ById<TModel>(int id)
        {
            return By<TModel>(a => a.Id == id).SingleOrDefault();
        }

        public TModel ByName<TModel>(string name)
        {
            return By<TModel>(a => a.Name == name).SingleOrDefault();
        }

        public bool Exists(int id)
        {
            return ById<Town>(id) != null;
        }

        public bool Exists(string name)
        {
            return ByName<Town>(name) != null;
        }

        private IEnumerable<TModel> By<TModel>(Func<Town, bool> predicate)
            => this.photoShareContext
                   .Towns
                   .Where(predicate)
                   .AsQueryable()
                   .ProjectTo<TModel>();
    }
}
