//@DomainCode
//MdStart
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Contracts;
using MusicStore.Logic.Entities;
using MusicStore.Logic.Entities.Persistence;

namespace MusicStore.Logic.DataContext.Db
{
    internal partial class DbMusicStoreContext : DbContext, IContext, IMusicStoreContext
    {
        private static string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDb;Database=MusicStoreDb;Integrated Security=True;";

        static DbMusicStoreContext()
        {

        }

        public IQueryable<Genre> Genres => GenreSet;
        public IQueryable<Artist> Artists => ArtistSet;
        public IQueryable<Album> Albums => AlbumSet;
        public IQueryable<Track> Tracks => TrackSet;

        public DbSet<Genre> GenreSet { get; set; }
        public DbSet<Artist> ArtistSet { get; set; }
        public DbSet<Album> AlbumSet { get; set; }
        public DbSet<Track> TrackSet { get; set; }

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
			
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                .ToTable(nameof(Genre))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Genre>()
                .HasIndex(p => p.Name)
                .IsUnique();
            modelBuilder.Entity<Genre>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<Artist>()
                .ToTable(nameof(Artist))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Artist>()
                .HasIndex(p => p.Name)
                .IsUnique();
            modelBuilder.Entity<Artist>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(1024);

            modelBuilder.Entity<Album>()
                .ToTable(nameof(Album))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Album>()
                .HasIndex(p => p.Title)
                .IsUnique();
            modelBuilder.Entity<Album>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(1024);

            modelBuilder.Entity<Track>()
                .ToTable(nameof(Track))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Track>()
                .HasIndex(p => p.Title);
            modelBuilder.Entity<Track>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(1024);
            modelBuilder.Entity<Track>()
                .Property(p => p.Composer)
                .HasMaxLength(512);
        }
        #endregion Configuration

        #region IContext
        #region Sync-Methods
        public int Count<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Set<E>().Count();
        }
        public E Create<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return new E();
        }
        public E Insert<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            entity.CheckArgument(nameof(entity));

            Set<E>().Add(entity);
            return entity;
        }
        public E Update<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            entity.CheckArgument(nameof(entity));

            Set<E>().Update(entity);
            return entity;
        }
        public E Delete<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            E result = Set<E>().SingleOrDefault(i => i.Id == id);

            if (result != null)
            {
                Set<E>().Remove(result);
            }
            return result;
        }
        public void Save()
        {
            base.SaveChanges();
        }
		#endregion Sync-Methods
        #endregion IContext
    }
}
//MdEnd