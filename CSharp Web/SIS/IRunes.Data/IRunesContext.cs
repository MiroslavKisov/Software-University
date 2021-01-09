namespace IRunes.Data
{
    using Configuration;
    using Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class IRunesContext : DbContext
    {
        public IRunesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public IRunesContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.connectionString).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
