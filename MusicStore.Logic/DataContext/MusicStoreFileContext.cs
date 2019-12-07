using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBase.Extensions;

namespace MusicStore.Logic.DataContext
{
    abstract partial class MusicStoreFileContext : FileContext, IMusicStoreContext
    {
        private readonly List<Entities.Persistence.Genre> genres = null;
        public IEnumerable<Entities.Persistence.Genre> Genres => genres;
        private readonly List<Entities.Persistence.Artist> artists = null;
        public IEnumerable<Entities.Persistence.Artist> Artists => artists;
        private readonly List<Entities.Persistence.Album> albums = null;
        public IEnumerable<Entities.Persistence.Album> Albums => albums;
        private readonly List<Entities.Persistence.Track> tracks = null;
        public IEnumerable<Entities.Persistence.Track> Tracks => tracks;

        public MusicStoreFileContext()
        {
            genres = LoadEntities<Entities.Persistence.Genre>();
            artists = LoadEntities<Entities.Persistence.Artist>();
            albums = LoadEntities<Entities.Persistence.Album>();
            tracks = LoadEntities<Entities.Persistence.Track>();
            //LoadRelations();
        }
        #region Load methods
        protected abstract List<T> LoadEntities<T>()
            where T : class, new();
        protected void LoadRelations()
        {
            // Load reference data for track items
            tracks.ForEach(t =>
            {
                t.Album = albums.SingleOrDefault(i => i.Id == t.AlbumId);
                t.Genre = genres.SingleOrDefault(i => i.Id == t.GenreId);
            });
            // Load reference data for album items
            albums.ForEach(a =>
            {
                a.Artist = artists.SingleOrDefault(ar => ar.Id == a.ArtistId);
                a.Tracks = tracks.Where(t => t.AlbumId == a.Id);
            });
            // Load reference data for artist items
            artists.ForEach(ar =>
            {
                ar.Albums = albums.Where(a => a.ArtistId == ar.Id);
            });
            // Load reference data for genre items
            genres.ForEach(g =>
            {
                g.Tracks = tracks.Where(t => t.GenreId == g.Id);
            });
        }
        #endregion Load methods

        #region Sync-Methods
        public override int Count<I, E>()
        {
            return Set<I, E>().Count;
        }
        public override E Create<I, E>()
        {
            return new E();
        }
        public override E Insert<I, E>(I entity)
        {
            entity.CheckArgument(nameof(entity));

            E result = new E();

            result.CopyProperties(entity);
            result.Id = 0;
            Set<I, E>().Add(result);
            return result;
        }
        public override E Update<I, E>(I entity)
        {
            entity.CheckArgument(nameof(entity));

            E result = Set<I, E>().SingleOrDefault(i => i.Id == entity.Id);

            if (result != null)
            {
                result.CopyProperties(entity);
            }
            return result;
        }
        public override E Delete<I, E>(int id)
        {
            E result = Set<I, E>().SingleOrDefault(i => i.Id == id);

            if (result != null)
            {
                Set<I, E>().Remove(result);
            }
            return result;
        }
        #endregion Sync-Methods

        #region Async-Methods
		// Falls die synchronen Methoden entfernt werden soll,
		// dann werden diese private spezifiziert und aus dem 
		// Interface entfernt.
        public override Task<int> CountAsync<I, E>()
        {
            return Task.Run(() => Count<I, E>());
        }
        public override Task<E> CreateAsync<I, E>()
        {
            return Task.Run(() => Create<I, E>());
        }
        public override Task<E> InsertAsync<I, E>(I entity)
        {
            entity.CheckArgument(nameof(entity));

			return Task.Run(() => Insert<I, E>(entity));
        }
        public override Task<E> UpdateAsync<I, E>(I entity)
        {
            entity.CheckArgument(nameof(entity));

			return Task.Run(() => Update<I, E>(entity));
        }
        public override Task<E> DeleteAsync<I, E>(int id)
        {
			return Task.Run(() => Delete<I, E>(id));
        }
        #endregion Async-Methods

        #region Helpers
        protected List<E> Set<I, E>()
            where I : Contracts.IIdentifiable
            where E : Entities.IdentityObject, I
        {
            List<E> result;

            if (typeof(I) == typeof(Contracts.Persistence.IGenre))
            {
                result = genres as List<E>;
            }
            else if (typeof(I) == typeof(Contracts.Persistence.IArtist))
            {
                result = artists as List<E>;
            }
            else if (typeof(I) == typeof(Contracts.Persistence.IAlbum))
            {
                result = albums as List<E>;
            }
            else if (typeof(I) == typeof(Contracts.Persistence.ITrack))
            {
                result = tracks as List<E>;
            }
            else
            {
                throw new ArgumentException(
                               message: "entity is not a recognized entity",
                               paramName: nameof(I));
            }
            return result;
        }
        protected E GetById<I, E>(int id)
            where I : Contracts.IIdentifiable
            where E : Entities.IdentityObject, I
        {
            return Set<I, E>().SingleOrDefault(i => i.Id == id);
        }
        #endregion Helpers
    }
}
