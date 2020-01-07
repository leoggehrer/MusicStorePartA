//@BaseCode
//MdStart
using System;
using MusicStore.Contracts.Client;

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
        /// <summary>
        /// Get and sets the persistence type.
        /// </summary>
        public static PersistenceType Persistence { get; set; } = Factory.PersistenceType.Csv;

        /// <summary>
        /// This method creates the 'DataContext' depending on the persist type.
        /// </summary>
        /// <returns>An instance of the 'DataContext' type.</returns>
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
        /// <summary>
        /// This method creates a controller object depending on the interface type 
        /// and passes its interface to the caller.
        /// </summary>
        /// <typeparam name="T">The interface type.</typeparam>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<T> Create<T>() where T : Contracts.IIdentifiable
        {
            IControllerAccess<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.IGenre))
            {
                result = (IControllerAccess<T>)CreateGenreController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IArtist))
            {
                result = (IControllerAccess<T>)CreateArtistController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IAlbum))
            {
                result = (IControllerAccess<T>)CreateAlbumController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.ITrack))
            {
                result = (IControllerAccess<T>)CreateTrackController();
            }
            return result;
        }
        /// <summary>
        /// Depending on the interface type, this method creates a controller object 
        /// and transfers its interface to the caller. The DataContext object is used 
        /// from the parameter object.
        /// </summary>
        /// <typeparam name="T">The interface type.</typeparam>
        /// <param name="sharedController">The controller object from which the DataContext is to be shared.</param>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<T> Create<T>(object sharedController) where T : Contracts.IIdentifiable
        {
            IControllerAccess<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.IGenre))
            {
                result = (IControllerAccess<T>)CreateGenreController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IArtist))
            {
                result = (IControllerAccess<T>)CreateArtistController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IAlbum))
            {
                result = (IControllerAccess<T>)CreateAlbumController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.ITrack))
            {
                result = (IControllerAccess<T>)CreateTrackController(sharedController);
            }
            return result;
        }
        /// <summary>
        /// This method creates a controller object for the genre entity type.
        /// </summary>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<Contracts.Persistence.IGenre> CreateGenreController()
        {
            return new Controllers.Persistence.GenreController(CreateContext());
        }
        /// <summary>
        /// This method creates a controller object for the genre entity type. The DataContext object is used 
        /// from the parameter object.
        /// </summary>
        /// <param name="sharedController">The controller object from which the DataContext is to be shared.</param>
        /// <returns>The controller's interface.</returns>
		public static IControllerAccess<Contracts.Persistence.IGenre> CreateGenreController(object sharedController)
		{
			if (sharedController == null)
				throw new ArgumentNullException(nameof(sharedController));

			Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

			return new Controllers.Persistence.GenreController(controller);
		}

        /// <summary>
        /// This method creates a controller object for the artist entity type.
        /// </summary>
        /// <returns>The controller's interface.</returns>
		public static IControllerAccess<Contracts.Persistence.IArtist> CreateArtistController()
		{
			return new Controllers.Persistence.ArtistController(CreateContext());
		}
        /// <summary>
        /// This method creates a controller object for the artist entity type. The DataContext object is used 
        /// from the parameter object.
        /// </summary>
        /// <param name="sharedController">The controller object from which the DataContext is to be shared.</param>
        /// <returns>The controller's interface.</returns>
		public static IControllerAccess<Contracts.Persistence.IArtist> CreateArtistController(object sharedController)
		{
			if (sharedController == null)
				throw new ArgumentNullException(nameof(sharedController));

			Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

			return new Controllers.Persistence.ArtistController(controller);
		}

        /// <summary>
        /// This method creates a controller object for the album entity type.
        /// </summary>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<Contracts.Persistence.IAlbum> CreateAlbumController()
        {
            return new Controllers.Persistence.AlbumController(CreateContext());
        }
        /// <summary>
        /// This method creates a controller object for the album entity type. The DataContext object is used 
        /// from the parameter object.
        /// </summary>
        /// <param name="sharedController">The controller object from which the DataContext is to be shared.</param>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<Contracts.Persistence.IAlbum> CreateAlbumController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Persistence.AlbumController(controller);
        }

        /// <summary>
        /// This method creates a controller object for the track entity type.
        /// </summary>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<Contracts.Persistence.ITrack> CreateTrackController()
        {
            return new Controllers.Persistence.TrackController(CreateContext());
        }
        /// <summary>
        /// This method creates a controller object for the track entity type. The DataContext object is used 
        /// from the parameter object.
        /// </summary>
        /// <param name="sharedController">The controller object from which the DataContext is to be shared.</param>
        /// <returns>The controller's interface.</returns>
        public static IControllerAccess<Contracts.Persistence.ITrack> CreateTrackController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Persistence.TrackController(controller);
        }
    }
}
//MdEnd
