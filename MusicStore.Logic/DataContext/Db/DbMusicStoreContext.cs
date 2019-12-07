using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Contracts;
using MusicStore.Logic.Entities;
using MusicStore.Logic.Entities.Persistence;

namespace MusicStore.Logic.DataContext.Db
{
    internal class DbMusicStoreContext : DbContext, IContext, IMusicStoreContext
    {
        private static string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDb;Database=MusicStoreDb;Integrated Security=True;";

        static DbMusicStoreContext()
        {

        }

        public IEnumerable<Genre> Genres => GenreSet.ToArray();
        public IEnumerable<Artist> Artists => ArtistSet.ToArray();
        public IEnumerable<Album> Albums => AlbumSet.ToArray();
        public IEnumerable<Track> Tracks => TrackSet.ToArray();

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
        public E Insert<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            E newEntity = new E();

            newEntity.CopyProperties(entity);
            newEntity.Id = 0;
            try
            {
                if (Entry(newEntity).State == EntityState.Detached)
                {
                    Entry(newEntity).State = EntityState.Added;
                }
            }
            catch
            {
                Entry(newEntity).State = EntityState.Detached;
                throw;
            }
            return newEntity;
        }
        public E Update<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            var updEntity = new E();

            updEntity.CopyProperties(entity);

            var omEntity = Entry(updEntity);

            if (omEntity.State == EntityState.Detached)
            {
                E attachedEntity = Set<E>().Local.SingleOrDefault(e => e.Id == entity.Id);

                if (attachedEntity != null)
                {
                    Entry(attachedEntity).CurrentValues.SetValues(entity);
                    Entry(attachedEntity).State = EntityState.Modified;
                }
                else
                {
                    omEntity.State = EntityState.Modified;
                }
            }
            else
            {
                EntityState saveState = omEntity.State;

                try
                {
                    Entry(entity).State = EntityState.Modified;
                }
                catch
                {
                    Entry(entity).State = saveState;
                    throw;
                }
            }
            return omEntity.Entity;
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

		#region Async-Methods
		// Falls die synchronen Methoden entfernt werden soll,
		// dann werden diese private spezifiziert und aus dem 
		// Interface entfernt.
		public Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Set<E>().CountAsync();
        }
        public Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() => Create<I, E>());
        }
        public Task<E> InsertAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
			return Task.Run(() => Insert<I, E>(entity));
        }
        public Task<E> UpdateAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
			return Task.Run(() => Update<I, E>(entity));
        }
        public Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I
        {
			return Task.Run(() => Delete<I, E>(id));
        }
        public Task SaveAsync()
        {
            return Task.Run(() => base.SaveChangesAsync());
        }
        #endregion Async-Methods
        #endregion IContext
    }
}
