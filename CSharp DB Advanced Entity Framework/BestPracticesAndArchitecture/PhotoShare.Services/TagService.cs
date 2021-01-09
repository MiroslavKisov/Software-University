namespace PhotoShare.Services
{
    using AutoMapper.QueryableExtensions;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TagService : ITagService
    {
        private readonly PhotoShareContext photoShareContext;

        public TagService(PhotoShareContext photoShareContext)
        {
            this.photoShareContext = photoShareContext;
        }

        public Tag AddTag(string name)
        {
            var tag = new Tag()
            {
                Name = "#" + name,
            };

            this.photoShareContext.Tags.Add(tag);

            this.photoShareContext.SaveChanges();

            return tag;
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
            return ById<Tag>(id) != null;
        }

        public bool Exists(string name)
        {
            return ByName<Tag>(name) != null;
        }

        private IEnumerable<TModel> By<TModel>(Func<Tag, bool> predicate)
            => this.photoShareContext
                   .Tags
                   .Where(predicate)
                   .AsQueryable()
                   .ProjectTo<TModel>();
    }
}
