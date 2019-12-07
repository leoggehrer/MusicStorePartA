using System;

namespace MusicStore.Logic
{
	public static class Factory
    {
        public enum PersistenceType
        {
            Db,
            Csv,
            Ser,
        }
        public static PersistenceType Persistence { get; set; } = Factory.PersistenceType.Csv;
        private static DataContext.IContext CreateContext()
        {
            DataContext.IContext result = null;

            if (Persistence == PersistenceType.Csv)
            {
                result = new DataContext.Csv.CsvMusicStoreContext();
            }
            else if (Persistence == PersistenceType.Db)
            {
                result = new DataContext.Db.DbMusicStoreContext();
            }
            else if (Persistence == PersistenceType.Ser)
            {
                result = new DataContext.Ser.SerMusicStoreContext();
            }
            return result;
        }

        public static IController<T> Create<T>() where T : Contracts.IIdentifiable
        {
            IController<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.IGenre))
            {
                result = (IController<T>)CreateGenreController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IArtist))
            {
                result = (IController<T>)CreateArtistController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IAlbum))
            {
                result = (IController<T>)CreateAlbumController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.ITrack))
            {
                result = (IController<T>)CreateTrackController();
            }
            return result;
        }
        public static IController<T> Create<T>(object sharedController) where T : Contracts.IIdentifiable
        {
            IController<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.IGenre))
            {
                result = (IController<T>)CreateGenreController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IArtist))
            {
                result = (IController<T>)CreateArtistController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IAlbum))
            {
                result = (IController<T>)CreateAlbumController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.ITrack))
            {
                result = (IController<T>)CreateTrackController(sharedController);
            }
            return result;
        }

        public static IController<Contracts.Persistence.IGenre> CreateGenreController()
        {
            return new Controllers.Persistence.GenreController(CreateContext());
        }
		public static IController<Contracts.Persistence.IGenre> CreateGenreController(object sharedController)
		{
			if (sharedController == null)
				throw new ArgumentNullException(nameof(sharedController));

			Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

			return new Controllers.Persistence.GenreController(controller);
		}

		public static IController<Contracts.Persistence.IArtist> CreateArtistController()
		{
			return new Controllers.Persistence.ArtistController(CreateContext());
		}
		public static IController<Contracts.Persistence.IArtist> CreateArtistController(object sharedController)
		{
			if (sharedController == null)
				throw new ArgumentNullException(nameof(sharedController));

			Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

			return new Controllers.Persistence.ArtistController(controller);
		}

        public static IController<Contracts.Persistence.IAlbum> CreateAlbumController()
        {
            return new Controllers.Persistence.AlbumController(CreateContext());
        }
        public static IController<Contracts.Persistence.IAlbum> CreateAlbumController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Persistence.AlbumController(controller);
        }

        public static IController<Contracts.Persistence.ITrack> CreateTrackController()
        {
            return new Controllers.Persistence.TrackController(CreateContext());
        }
        public static IController<Contracts.Persistence.ITrack> CreateTrackController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Persistence.TrackController(controller);
        }
    }
}
