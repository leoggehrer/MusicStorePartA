namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// This interface defines properties of a track.
    /// </summary>
	public interface ITrack : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the reference id from album.
        /// </summary>
        int AlbumId { get; set; }
        /// <summary>
        /// Gets or sets the reference id from genre.
        /// </summary>
        int GenreId { get; set; }
        /// <summary>
        /// Gets or sets the title of this instance.
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Gets or sets the composer of this instance.
        /// </summary>
		string Composer { get; set; }
        /// <summary>
        /// Gets or sets the milliseconds of this instance.
        /// </summary>
        long Milliseconds { get; set; }
        /// <summary>
        /// Gets or sets the bytes of this instance.
        /// </summary>
        long Bytes { get; set; }
        /// <summary>
        /// Gets or sets the unitprice of this instance.
        /// </summary>
        double UnitPrice { get; set; }
    }
}
